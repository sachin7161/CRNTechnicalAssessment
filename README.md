# CRN Technical Assessment

## Project Overview

This project is a RESTful Web API built using ASP.NET Core 8 following Clean Architecture principles.

It provides JWT Authentication, Product CRUD operations, SQL Server integration, Docker support, Swagger documentation, and Unit Testing.

---

## Tech Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- AutoMapper
- FluentValidation
- Serilog
- Swagger
- Docker
- xUnit
- Moq

---

## Project Architecture

- API
- Application
- Domain
- Infrastructure
- Tests

---

## Features

- JWT Authentication
- Product CRUD
- Repository Pattern
- Service Layer
- Global Exception Middleware
- SQL Server
- Docker Compose
- Swagger UI
- Unit Testing

---

## Running the Project

### Clone Repository

```bash
git clone https://github.com/sachin7161/CRNTechnicalAssessment.git
```

### Run Docker

```bash
docker compose up --build
```

### Swagger

```
https://localhost:7206/swagger
```

---

## Authentication

Login API

```
POST /api/Auth/login
```

Sample Request

```json
{
  "username": "admin",
  "password": "Password@123"
}
```

---

## Product APIs

```
GET    /api/Product

GET    /api/Product/{id}

POST   /api/Product

PUT    /api/Product/{id}

DELETE /api/Product/{id}
```

---

## Testing

Run Tests

```bash
dotnet test
```

Result

```
8 Tests Passed
```

---

## Docker

Run

```bash
docker compose up --build
```

Stop

```bash
docker compose down
```

---

## Author

Sachin Kalel

.NET Full Stack Developer

GitHub

https://github.com/sachin7161
