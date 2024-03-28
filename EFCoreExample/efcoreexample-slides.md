---
marp: true
theme: wctc
style: |
  @import 'wctc-theme.css';
---
![WCTC Logo](https://www.wctc.edu/_resources/images/waukesha_logo.svg)

# EFCoreExample: A .NET Core Application
*Instructor: Mark McArthey*

---

# Overview

- EFCoreExample is a .NET Core application that demonstrates the use of Entity Framework Core.
- It provides a simple interface for managing classrooms and students.
- The application uses different databases depending on the environment: SQLite for testing and SQL Server for development and production.

---

# Application Structure

- The application is divided into several classes, each with a specific responsibility.
- This follows the Single Responsibility Principle, making the code easier to understand and maintain.

---

# MainService

- The `MainService` class is the entry point for the application's functionality.
- It uses the `SchoolRepository` to interact with the database and `IConsoleService` for console interactions.
```csharp
    public MainService(ISchoolRepository repository, IConsoleService consoleService)
    {
        _repository = repository;
        _consoleService = consoleService;
    }
```
---

# SchoolRepository

- The `SchoolRepository` class provides methods for querying and updating the database.
- It uses the `SchoolContext` for database interactions.
```csharp
    public SchoolRepository(ISchoolContext context)
    {
        _context = context;
    }
```
---

# SchoolContext

- The `SchoolContext` class is the Entity Framework DbContext for the application.
- It contains `DbSet` properties for each of the entities in the model.
```csharp
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Student> Students { get; set; }
```

---

# IConsoleService and ConsoleService

- The `IConsoleService` interface and `ConsoleService` class abstract the console interactions.
- This makes the code easier to test and more flexible.
```csharp
    string ReadLine();
    void WriteLine(string message);
    void Write(string message);
```
---

# Entity Classes

- The `Classroom` and `Student` classes represent the entities in the model.
- They are simple classes with properties for each field in the database.
- Make a note of the virtual navigation properties which inform EF about the relationships.
```csharp
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Classroom> Classrooms { get; set; }
```
---

# Configuration

- The application's configuration is stored in `appsettings.json` files.
- There are separate files for each environment.
```csharp
    "ConnectionStrings": { "DefaultConnection": .... }
```
---

# Migrations

- The application uses Entity Framework Core Migrations to manage the database schema.
- Note in Program.cs where any pending migrations are run.
```csharp
    dbContext.Database.Migrate();
```

---

# Testing

- The application includes unit tests, which are located in a separate project.
- The tests use xUnit and Moq.

---

# Conclusion

- EFCoreExample demonstrates how to structure a .NET Core application using Entity Framework Core.
- It follows good practices like the Single Responsibility Principle and uses abstractions to make the code easier to test.
