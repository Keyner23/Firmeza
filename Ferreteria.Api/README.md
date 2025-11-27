# Ferretería API

REST API developed in ASP.NET Core for managing ferreteria operations, including authentication, customers, products, and sales.

## Features

- 🔐 Authentication and authorization
- 👥 Customer management
- 📦 Product management
- 🛒 Sales management
- ✅ Data validation

## Technologies

- **Framework:** ASP.NET Core
- **Language:** C#
- **Database:** [Specify: SQL Server, PostgreSQL, supabase.]
- **Authentication:** [JWT, Identity, etc.]

## Prerequisites

- .NET SDK 8.0 or higher
- SQL Server or your configured database

## Installation

```bash
cd Ferreteria.Api
dotnet restore
dotnet build
```
## Running
Development
```bash
dotnet run
```
The API will be available at https://localhost:5001 (or configured port)
API Endpoints

### Authentication
POST /api/auth/login - Login

### Products
- GET /api/products - List products
-POST /api/products - Create product
- DELETE /api/products/{id} - Delete product

### Sales
- GET /api/sales - List sales
- POST /api/sales - Create sale
- GET /api/sales/{id} - Get sale details

## Configuration
Edit appsettings.json to configure:
- Database connection string
- Environment variables
- Authentication settings

Project Structure

```bash
├── Controllers/       # API controllers
├── Program.cs         # Main configuration
├── appsettings.json   # Production settings
└── Properties/        # Project properties
```

