# Supermarket System (Full Stack)

Full-stack supermarket management system built with **ASP.NET Core 8 + Angular 21.2.7.** using Clean Architecture principles.

---

## Tech Stack

### Backend
- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- Clean Architecture (Domain / Application / Infrastructure / API)

### Frontend
- Angular 21.2.7
- TypeScript
- RxJS
- TailwindCSS
- HttpClient

---

## Project Structure
Supermarket/
  │
  ├── Supermarket.Api
  ├── Supermarket.Application
  ├── Supermarket.Domain
  ├── Supermarket.Infrastructure
  ├── Supermarket.Frontend
  └── Supermarket.sln

## Architecture Overview

### Backend (Clean Architecture)
- **Domain** → business entities and rules
- **Application** → use cases and business logic
- **Infrastructure** → database access (EF Core)
- **API** → REST controllers

### Frontend (Feature-based structure)

features/
  products/
    pages/
    components/
    services/
    models/
### Inventory (in progress)
- Stock quantity calculated from product batches
- Stock movement tracking (events-based approach planned)

---

## API Endpoints

### Products

GET /api/products
POST /api/products
PUT /api/products/{id}
DELETE /api/products/{id}

Backend API runs on:
https://localhost:5226

Frontend runs on:
http://localhost:4200

