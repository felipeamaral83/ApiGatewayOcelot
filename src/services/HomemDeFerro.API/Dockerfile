#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/HomemDeFerro.API/HomemDeFerro.API.csproj", "src/services/HomemDeFerro.API/"]
RUN dotnet restore "src/services/HomemDeFerro.API/HomemDeFerro.API.csproj"
COPY . .
WORKDIR "/src/src/services/HomemDeFerro.API"
RUN dotnet build "HomemDeFerro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomemDeFerro.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomemDeFerro.API.dll"]