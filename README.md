# Employee Management System (.NET Core)

## 📁 Architecture Overview

The solution is organized into four main layers:

### 🧠 Domain
- Contains core business entities like `Employee` and `User`
- No dependencies on any other layer

### 💼 Application
- Contains interfaces, use cases, and DTOs
- Defines contracts for services, without implementation

### 🗃️ Database (Infrastructure)
- Contains Entity Framework Core setup (`AppDbContext`)
- Implements repository interfaces and migrations
- Contains stored procedure support (if applicable)

### 🎯 UI
- ASP.NET Core Web API (or Console App)
- Handles HTTP requests or user input and calls application services

---
## 🚀 Features
- User Registration and Login
- Employee CRUD: Add, Edit, Delete, List
- Clean architecture using EF Core and Repository Pattern

## 🧱 Technologies
- .NET 8
- Entity Framework Core
- SQL Server
- ASP.NET Core Web APP 

## 🛠️ Setup Instructions

1. Clone the repository
2. Update `appsettings.json` with your SQL Server connection string
3. Run database migrations: `dotnet ef database update`
4. Run the project: `dotnet run`


## 🗃️ Database
- Table: Users
- Table: Employees
- Stored procedures included for optional use



## 👨‍💻 Author
Prajwal Lama
