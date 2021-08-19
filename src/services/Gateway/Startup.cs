using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;

namespace Gateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            var ocelotConfigPath = Path.Combine(webHostEnvironment.ContentRootPath, "OcelotConfig");
            ocelotConfigPath = Path.Combine(ocelotConfigPath, webHostEnvironment.EnvironmentName);

            var builder = new ConfigurationBuilder()
                .SetBasePath(webHostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json", true, true)
                .AddOcelot(webHostEnvironment) // .AddJsonFile("ocelot.json", true, true)
                // Configuração para o swagger
                .AddOcelotWithSwaggerSupport((x) =>
                {
                    x.Folder = ocelotConfigPath;
                })
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddOcelot(Configuration); Suficiente para o funcionamento do Ocelot (sem cache)

            services.AddOcelot(Configuration)
                // Configuração para habilitar o cache
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();
                });

            // Serviço para funcionar o swagger
            services.AddSwaggerForOcelot(Configuration);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("GATEWAY ON-LINE");
                });
            });

            // Middleware
            app.UseOcelot().Wait();
        }
    }
}
