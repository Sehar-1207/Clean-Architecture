# 🌴 ParadisePlanner Resorts API

<div align="center">


[![GitHub stars](https://img.shields.io/github/stars/Sehar-1207/Clean-Architecture?style=for-the-badge)](https://github.com/Sehar-1207/Clean-Architecture/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/Sehar-1207/Clean-Architecture?style=for-the-badge)](https://github.com/Sehar-1207/Clean-Architecture/network)
[![GitHub issues](https://img.shields.io/github/issues/Sehar-1207/Clean-Architecture?style=for-the-badge)](https://github.com/Sehar-1207/Clean-Architecture/issues)
[![GitHub license](https://img.shields.io/github/license/Sehar-1207/Clean-Architecture?style=for-the-badge)](LICENSE)

**A robust ASP.NET Core Web API for managing resort bookings, built with Clean Architecture principles.**

</div>

## 📖 Overview

This repository hosts the backend API for the ParadisePlanner resort booking system, meticulously crafted following **Clean Architecture** principles. It provides a highly maintainable, scalable, and testable foundation for managing all aspects of a resort, including resorts, rooms, and bookings. Designed to serve various client applications (web, mobile, desktop), this API emphasizes separation of concerns, making it easy to understand, extend, and evolve.

## ✨ Features

-   🎯 **Resort Management**: Full CRUD (Create, Read, Update, Delete) operations for managing resort properties.
-   🏨 **Room Management**: Define and manage different types of rooms available at each resort.
-   🗓️ **Booking System**: Core functionality for creating, retrieving, and managing room bookings.
-   🔒 **Authentication & Authorization**: Secure API access with industry-standard authentication mechanisms (presumed, common for such APIs).
-   🛡️ **Clean Architecture**: Adherence to Domain, Application, Infrastructure, and Presentation layers for a modular and resilient design.
-   🚀 **Scalable & Performant**: Built on ASP.NET Core, optimized for high throughput and responsiveness.
-   ✅ **Testable Design**: Decoupled layers facilitate comprehensive unit and integration testing.

## 🛠️ Tech Stack

**Backend:**
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-blue?style=for-the-badge)

**Database:**
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white) <!-- Presumed primary database. Can be easily swapped. -->

## 🚀 Quick Start

### Prerequisites
Before you begin, ensure you have the following installed:
-   **[.NET SDK](https://dotnet.microsoft.com/download)** (version 6.0 or newer recommended)
-   **SQL Server** (or compatible database) configured and running.

### Installation

1.  **Clone the repository**
    ```bash
    git clone https://github.com/Sehar-1207/Clean-Architecture.git
    cd Clean-Architecture
    ```

2.  **Restore dependencies**
    Navigate to the solution directory and restore NuGet packages:
    ```bash
    dotnet restore ParadisePlannerResorts.sln
    ```

3.  **Environment setup**
    Configure your database connection string and other settings.
    -   Open `ParadisePlannerResorts/appsettings.json` (and `appsettings.Development.json`).
    -   Update the `ConnectionStrings` section to point to your SQL Server instance.
        ```json
        {
          "ConnectionStrings": {
            "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ParadisePlannerDb;User ID=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
          },
          // ... other configurations
        }
        ```

4.  **Database setup**
    Apply Entity Framework Core migrations to create the database schema:
    ```bash
    dotnet ef database update --project ParadisePlanner.Infrastructure --startup-project ParadisePlannerResorts
    ```
    *Note: If this is the first time setting up, you might need to create initial migrations:*
    ```bash
    dotnet ef migrations add InitialCreate --project ParadisePlanner.Infrastructure --startup-project ParadisePlannerResorts
    dotnet ef database update --project ParadisePlanner.Infrastructure --startup-project ParadisePlannerResorts
    ```

5.  **Start development server**
    Run the API project:
    ```bash
    dotnet run --project ParadisePlannerResorts
    ```

6.  **Access the API**
    The API will typically be available at `http://localhost:[detected port]` (e.g., `http://localhost:5000` or `http://localhost:5001` for HTTPS). Swagger UI for API documentation is usually available at `http://localhost:[port]/swagger`.

## 📁 Project Structure

This project is organized according to **Clean Architecture** principles, separating concerns into distinct layers:

```
Clean-Architecture/
├── ParadisePlanner.Application/     # Application layer: Defines what the application does.
│   ├── Features/                    # Use cases, queries, commands (e.g., MediatR handlers)
│   ├── Services/                    # Application services
│   └── Interfaces/                  # Interfaces for infrastructure dependencies
├── ParadisePlanner.Domain/          # Domain layer: Core business rules and entities.
│   ├── Entities/                    # Aggregate roots, entities
│   ├── ValueObjects/                # Value objects
│   ├── Exceptions/                  # Custom domain exceptions
│   └── Enums/                       # Domain-specific enumerations
├── ParadisePlanar.Infrastructure/   # Infrastructure layer: Implementation details.
│   ├── Data/                        # Database context (EF Core), migrations
│   ├── Repositories/                # Concrete implementations of repository interfaces
│   ├── Services/                    # Implementations of external services
│   └── Migrations/                  # EF Core database migration files
├── ParadisePlannerResorts/          # Presentation/API layer: ASP.NET Core Web API project.
│   ├── Controllers/                 # API endpoints
│   ├── Program.cs                   # Application entry point (.NET 6+)
│   ├── appsettings.json             # Configuration files
│   ├── Properties/                  # Launch settings etc.
│   └── .csproj                      # Project file with dependencies
└── ParadisePlannerResorts.sln       # Visual Studio Solution file
```

## ⚙️ Configuration

### Environment Variables
Sensitive information like database connection strings, API keys, and other settings can be configured via `appsettings.json` or overridden by environment variables. Common environment variable names typically follow the `ASPNETCORE_` prefix or direct `ConnectionStrings__DefaultConnection` patterns.

### Configuration Files
-   `appsettings.json`: Main application configuration.
-   `appsettings.Development.json`: Overrides for development environment.
-   `appsettings.Production.json`: Overrides for production environment.

## 🔧 Development

### Available Commands

| Command                                                                 | Description                                             |
| :---------------------------------------------------------------------- | :------------------------------------------------------ |
| `dotnet restore`                                                        | Restores NuGet packages for the entire solution.        |
| `dotnet build`                                                          | Builds all projects in the solution.                    |
| `dotnet run --project ParadisePlannerResorts`                           | Starts the API development server.                      |
| `dotnet ef migrations add [Name] --project ParadisePlanner.Infrastructure --startup-project ParadisePlannerResorts` | Creates a new database migration.                       |
| `dotnet ef database update --project ParadisePlanner.Infrastructure --startup-project ParadisePlannerResorts`     | Applies pending migrations to the database.             |
| `dotnet test`                                                           | Runs all tests in the solution (if test projects exist). |

## 🧪 Testing

This architecture is designed for testability. Unit tests typically reside in separate test projects (e.g., `ParadisePlanner.Application.Tests`, `ParadisePlanner.Domain.Tests`). Integration tests for the API and infrastructure components would also have their dedicated projects.

To run tests:
```bash
# Build the solution (ensures latest changes are compiled)
dotnet build

# Run all tests in the solution
dotnet test
```

## 🚀 Deployment

### Production Build
To create a production-ready build of the API:
```bash
dotnet publish --project ParadisePlannerResorts -c Release -o ./publish
```
This will compile the application and its dependencies into the `./publish` folder, ready for deployment.

### Deployment Options
-   **Docker**: Create a `Dockerfile` to containerize the application for deployment to platforms like Kubernetes or Docker Swarm.
-   **Azure App Service / AWS Elastic Beanstalk**: Publish the `publish` folder directly to cloud hosting services.
-   **IIS / Kestrel**: Host the application on a Windows Server (IIS) or Linux machine (Kestrel behind a reverse proxy like Nginx).

## 📚 API Reference

The API endpoints are defined within the `ParadisePlannerResorts/Controllers` directory. A Swagger UI interface is typically enabled in development environments for interactive API exploration.

### Authentication
(Details on authentication methods, e.g., JWT, OAuth, API Key, would go here.)

### Endpoints (Examples)

**Resorts**
-   `GET /api/resorts`: Retrieve a list of all resorts.
-   `GET /api/resorts/{id}`: Get details of a specific resort.
-   `POST /api/resorts`: Create a new resort.
-   `PUT /api/resorts/{id}`: Update an existing resort.
-   `DELETE /api/resorts/{id}`: Delete a resort.

**Rooms**
-   `GET /api/resorts/{resortId}/rooms`: Get rooms for a specific resort.
-   `POST /api/resorts/{resortId}/rooms`: Add a new room to a resort.

**Bookings**
-   `GET /api/bookings`: Retrieve all bookings.
-   `POST /api/bookings`: Create a new booking.
-   `GET /api/bookings/{id}`: Get details of a specific booking.

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) <!-- TODO: Create CONTRIBUTING.md --> for details on how to get started, report bugs, or suggest features.

### Development Setup for Contributors
The development setup is as described in the [Quick Start](#quick-start) section. Ensure your local environment is configured for .NET development and has access to a SQL Server instance.

## 📄 License

This project is licensed under the [LICENSE_NAME](LICENSE) <!-- TODO: Specify license file (e.g., MIT, Apache 2.0) and link --> - see the LICENSE file for details.

## 🙏 Acknowledgments

-   Inspired by best practices in **Clean Architecture** for .NET applications.
-   Utilizes **ASP.NET Core** for robust web API capabilities.
-   Leverages **Entity Framework Core** for seamless data access.

## 📞 Support & Contact

-   📧 Email: [seharajmal452@gmail.com] <!-- TODO: Add contact email -->
-   🐛 Issues: [GitHub Issues](https://github.com/Sehar-1207/Clean-Architecture/issues)

---

<div align="center">

**⭐ Star this repo if you find it helpful!**

Made with ❤️ by [Sehar Ajmal](https://github.com/Sehar-1207)

</div>
