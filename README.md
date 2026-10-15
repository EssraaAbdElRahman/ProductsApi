# Products API

A RESTful API built with **ASP.NET Core 10** following **Clean Architecture** and the **CQRS** pattern.

## Features
- Clean separation: Domain / Application / Infrastructure / API
- CQRS with MediatR (Commands & Queries)
- Request validation with FluentValidation via a MediatR pipeline behavior
- Global exception handling returning standard `ProblemDetails`
- EF Core 10 with SQL Server and the Repository pattern
- DTOs separate from domain entities

## Architecture
Api → Application ← Infrastructure
↓
Domain
Dependencies always point inward toward the Domain layer.

## Tech Stack
.NET 10 · EF Core 10· SQL Server · MediatR · FluentValidation · Swagger

## Endpoints
| Method | Route | Description |
|---|---|---|
| GET | /api/products | Get all products |
| GET | /api/products/{id} | Get product by id |
| POST | /api/products | Create a product |

## Getting Started
1. Update the connection string in `ProductsApi.Api/appsettings.json`
2. Apply migrations:
   `dotnet ef database update -p ProductsApi.Infrastructure -s ProductsApi.Api`
3. Run: `dotnet run --project ProductsApi.Api`
4. Open Swagger at `https://localhost:<port>/swagger`
