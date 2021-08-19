#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/PanteraNegra.API/PanteraNegra.API.csproj", "src/services/PanteraNegra.API/"]
RUN dotnet restore "src/services/PanteraNegra.API/PanteraNegra.API.csproj"
COPY . .
WORKDIR "/src/src/services/PanteraNegra.API"
RUN dotnet build "PanteraNegra.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PanteraNegra.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PanteraNegra.API.dll"]