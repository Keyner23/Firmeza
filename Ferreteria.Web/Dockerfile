
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiamos csproj del proyecto Web
COPY ["Ferreteria.Web/Ferreteria.Web.csproj", "Ferreteria.Web/"]

# Copiamos proyectos dependientes
COPY ["src/Ferreteria.Application/Ferreteria.Application.csproj", "src/Ferreteria.Application/"]
COPY ["src/Ferreteria.Infrastructure/Ferreteria.Infrastructure.csproj", "src/Ferreteria.Infrastructure/"]


RUN dotnet restore "Ferreteria.Web/Ferreteria.Web.csproj"


COPY . .

# Build
WORKDIR "/src/Ferreteria.Web"
RUN dotnet build "Ferreteria.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ferreteria.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ferreteria.Web.dll"]
