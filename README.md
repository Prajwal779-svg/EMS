# 🧱 Clean Architecture ASP.NET Core Solution

This project is built using the **Clean Architecture** pattern to ensure maintainability, testability, and separation of concerns across the codebase.

---

## 📁 Architecture Overview

The solution is organized into four main layers:

### 🧠 Domain
- Contains core business entities like `Employee` and `User`
- No dependencies on any other layer

### 💼 Application
- Contains interfaces, use cases, and DTOs
- Defines contracts for services, without implementation

### 🗃️ Database (Infrastructure)
- Implements Entity Framework Core (`AppDbContext`)
- Contains:
  - Repository implementations
  - EF Core migrations
  - Stored procedure support (if applicable)

### 🎯 UI
- Built with **ASP.NET Core Web App** (or Console App)
- Handles HTTP requests or user input
- Invokes application services

---

## 🚀 Features

- 🔐 User Registration and Login
- 🧑‍💼 Employee CRUD operations: Add, Edit, Delete, List
- 🧹 Clean architecture using EF Core and Repository Pattern

---

## 🧱 Technologies

- .NET 8
- Entity Framework Core
- SQL Server
- ASP.NET Core Web API

---

## 🛠️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
