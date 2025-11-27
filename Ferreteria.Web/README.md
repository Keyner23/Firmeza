# Ferretería Web

Web application built with ASP.NET Core MVC for managing ferreteria operations, providing an interface for customers, products, sales, and dashboard analytics.

## Features

- 🎨 Responsive user interface
- 🔐 Authentication and authorization
- 👥 Customer management
- 📦 Product catalog management
- 🛒 Sales and orders tracking
- 📊 Dashboard with analytics
- 🏠 Home page with navigation

## Technologies

- **Framework:** ASP.NET Core MVC
- **Language:** C#
- **Frontend:** Razor Views, HTML, CSS, JavaScript
- **Database:** [Specify: SQL Server, PostgreSQL, etc.]
- **Authentication:** [ASP.NET Core Identity, OAuth, etc.]

## Prerequisites

- .NET SDK 8.0 or higher
- SQL Server or your configured database

## Installation

```bash
cd Ferreteria.Web
dotnet restore
dotnet build
```

## Running
Development
```bash
dotnet run
```

## Project Structure
```bash
├── appsettings.Development.json
├── appsettings.json
├── bin
│   └── Debug
├── Controllers
│   ├── AuthController.cs
│   ├── CustomerController.cs
│   ├── DashboardController.cs
│   ├── HomeController.cs
│   ├── ProductController.cs
│   └── SalesController.cs
├── Ferreteria.Web.csproj
├── Models
│   └── ErrorViewModel.cs
├── obj
│   ├── Debug
│   ├── Ferreteria.Web.csproj.EntityFrameworkCore.targets
│   ├── Ferreteria.Web.csproj.nuget.dgspec.json
│   ├── Ferreteria.Web.csproj.nuget.g.props
│   ├── Ferreteria.Web.csproj.nuget.g.targets
│   ├── project.assets.json
│   ├── project.nuget.cache
│   ├── project.packagespec.json
│   ├── rider.project.model.nuget.info
│   └── rider.project.restore.info
├── Program.cs
├── Properties
│   └── launchSettings.json
├── README.md
├── ViewModels
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
├── Views
│   ├── Auth
│   ├── Customer
│   ├── Dashboard
│   ├── Home
│   ├── Product
│   ├── Sales
│   ├── Shared
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
└── wwwroot
├── css
├── favicon.ico
├── js
└── lib
```
## Modules

### Authentication
- User login and registration
- Session management
- Secure access control
### Products
- Browse product catalog
- Add new products
- Update product details
- Remove products

### Sales
- Create and manage sales orders
- Track order status
- View sales history
- 
### Dashboard
- Sales analytics
- Key performance indicators
- Data visualization

## Configuration
- Edit appsettings.json to configure:
- Database connection string
- Environment variables
- Authentication settings

## Integration
This application works with the Ferretería API for backend operations.
API Base URL: http://localhost:5231

## Contributors

<a href="https://github.com/migueweb/boa/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=Keyner23/firmeza" alt="Contributors" />
</a>