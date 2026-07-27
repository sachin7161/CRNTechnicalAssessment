# CRN Technical Assessment

## Project Overview

This project is a RESTful Web API built using **ASP.NET Core 8** following **Clean Architecture** principles.

The application provides JWT Authentication, Product CRUD operations, SQL Server integration, Docker support, Swagger documentation, and Unit Testing.

---

# Tech Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- AutoMapper
- FluentValidation
- Serilog
- Swagger / OpenAPI
- Docker & Docker Compose
- xUnit
- Moq

---

# Project Architecture

```
CRNTechnicalAssessment
│
├── CRNTechnicalAssessment.API
├── CRNTechnicalAssessment.Application
├── CRNTechnicalAssessment.Domain
├── CRNTechnicalAssessment.Infrastructure
└── CRNTechnicalAssessment.Tests
```

---

# Features

- JWT Authentication
- Product CRUD APIs
- Repository Pattern
- Unit of Work
- Service Layer
- Global Exception Middleware
- SQL Server Integration
- Docker & Docker Compose
- Swagger Documentation
- Unit Testing

---

# Getting Started

## Clone Repository

```bash
git clone https://github.com/sachin7161/CRNTechnicalAssessment.git

cd CRNTechnicalAssessment
```

---

## Run using .NET CLI

```bash
dotnet restore

dotnet build

dotnet run --project CRNTechnicalAssessment.API
```

---

## Run using Docker

```bash
docker compose up --build
```

Stop Containers

```bash
docker compose down
```

---

# Swagger

## Local

```
https://localhost:7206/swagger
```

## Docker

```
http://localhost:8080/swagger
```

---

# Authentication

## Login Endpoint

```http
POST /api/Auth/login
```

### Request

```json
{
  "username": "admin",
  "password": "Password@123"
}
```

---

# Product APIs

```http
GET      /api/Product

GET      /api/Product/{id}

POST     /api/Product

PUT      /api/Product/{id}

DELETE   /api/Product/{id}
```

---

# Testing

Run Tests

```bash
dotnet test
```

Result

```
8 Tests Passed
```

---

# Docker

Build & Run

```bash
docker compose up --build
```

Stop

```bash
docker compose down
```

---

# Project Highlights

- ASP.NET Core 8
- Clean Architecture
- Repository Pattern
- Unit of Work
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger/OpenAPI
- Docker Support
- Global Exception Handling
- AutoMapper
- FluentValidation
- Serilog Logging
- xUnit & Moq Testing

---

# Author

**Sachin Kalel**

.NET Full Stack Developer

GitHub

https://github.com/sachin7161
