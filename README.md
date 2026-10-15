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
