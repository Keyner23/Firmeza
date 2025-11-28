# 🛠️ Ferretería -- Sistema Web + API (.NET 8 + PostgreSQL + Docker)

Este proyecto es una solución completa para la gestión de ventas,
clientes e inventario de una ferretería.\
Incluye:

-   **API REST en .NET 8**\
-   **Aplicación Web (Frontend .NET o MVC)**\
-   **Base de datos PostgreSQL**\
-   **Arquitectura limpia (Clean Architecture)**\
-   **Despliegue con Docker Compose**

## 📦 Estructura del Proyecto
```bash
.
├── compose.yaml
├── Ferreteria.Api
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── bin
│   ├── Controllers
│   ├── Dockerfile
│   ├── Ferreteria.Api.csproj
│   ├── Ferreteria.Api.http
│   ├── obj
│   ├── Program.cs
│   ├── Properties
│   └── README.md
├── Ferreteria.Web
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── bin
│   ├── Controllers
│   ├── Dockerfile
│   ├── Ferreteria.Web.csproj
│   ├── Models
│   ├── obj
│   ├── Program.cs
│   ├── Properties
│   ├── README.md
│   ├── ViewModels
│   ├── Views
│   └── wwwroot
├── Firmeza.sln
├── Firmeza.sln.DotSettings.user
├── obj
│   └── Ferreteria.Infrastructure.EntityFrameworkCore.targets
└── src
├── Ferreteria.Application
├── Ferreteria.Domain
├── Ferreteria.Infrastructure
└── Ferreteria.Web
```
## 🚀 Requisitos

-   Docker & Docker Compose\
-   .NET SDK 8 (solo para desarrollo local opcional)

## 🐳 Despliegue con Docker Compose

Para levantar toda la solución (API, Web y DB):

    docker compose up --build -d

Para detener los contenedores:

    docker compose down

## ⚙️ Servicios

### 🔵 API -- Ferreteria.Api

-   **URL pública:** http://localhost:5000\
-   **Swagger:** http://localhost:5000/swagger\
-   Expuesta en el contenedor como `api:8080`.

### 🟢 Frontend -- Ferreteria.Web

-   **URL:** http://localhost:5001\
-   Se comunica con la API a través de:

```{=html}
<!-- -->
```
    API_URL=http://localhost:5000

### 🟣 Base de datos -- PostgreSQL

-   Host local: **localhost**
-   Puerto local: **5433**
-   Credenciales:

DB: fermeza\
USER: postgres\
PASS: postgres

## 🧩 Archivo docker-compose.yml

Contenido incluido en el repositorio.

## 🔧 Migraciones de Base de Datos

Para aplicar migraciones:

    dotnet ef database update --project Ferreteria.Infrastructure --startup-project Ferreteria.Api

## 📈 Características

-   Endpoints RESTful\
-   Entity Framework Core\
-   CORS configurado\
-   Contenedores para API, Web y DB\
-   Datos persistentes mediante volúmenes

## Contributors

<a href="https://github.com/keyner23/firmeza/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=Keyner23/firmeza" alt="Contributors" />
</a>
