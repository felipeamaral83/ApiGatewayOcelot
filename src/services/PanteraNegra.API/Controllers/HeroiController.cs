using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace PanteraNegra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            dynamic vingador = new ExpandoObject();
            vingador.Nome = "Pantera Negra";
            vingador.Ator = "Chadwick Boseman";

            return Ok(vingador);
        }
    }
}
