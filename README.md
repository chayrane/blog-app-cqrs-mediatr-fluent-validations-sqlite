# Blogs App

This project is a simple blogs application built using Clean Architecture principles in .NET Web API. It leverages MediatR for implementing the CQRS pattern.

## Table of Contents

- [Blogs App](#blogs-app)
  - [Table of Contents](#table-of-contents)
  - [Features](#features)
  - [Technologies](#technologies)
  - [Architecture](#architecture)
    - [Layers](#layers)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Usage](#usage)
    - [Sample Requests](#sample-requests)
      - [Create a Blog Post](#create-a-blog-post)
      - [Get All Blog Posts](#get-all-blog-posts)
  - [Contributing](#contributing)
  - [License](#license)

## Features

- Create, Read, Update, and Delete (CRUD) operations for blog posts.
- Separation of concerns through Clean Architecture.
- Command Query Responsibility Segregation (CQRS) pattern.
- MediatR for handling commands and queries.

## Technologies

- .NET 8
- ASP.NET Core Web API
- MediatR
- CQRS pattern
- Entity Framework Core (EF Core)
- AutoMapper
- FluentValidation
- Swagger/OpenAPI

## Architecture

The application follows the Clean Architecture principles, ensuring separation of concerns and maintainability.

### Layers

1. **Core**: Contains the domain entities and interfaces.
2. **Application**: Contains the business logic, commands, queries, and handlers using MediatR.
3. **Infrastructure**: Contains the implementation of the infrastructure services, such as the database context using EF Core.
4. **API**: Contains the controllers and is the entry point for the API.

## Getting Started

### Prerequisites

- .NET 8 SDK.
- SQLiteStudio for viewing db.

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/chayrane/blog-app-cqrs-mediatr-fluent-validations-sqlite.git
    cd blog-app-cqrs-mediatr-fluent-validations-sqlite
    ```

2. Set up the database connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=[your_server];Database=BlogsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

3. Apply database migrations:
    ```sh
    dotnet ef database update --project BlogsApp.Infrastructure
    ```

4. Run the application:
    ```sh
    dotnet run --project BlogsApp.API
    ```

### Usage

Once the application is running, you can explore the API endpoints using Swagger. By default, Swagger UI is available at `http://localhost:7083/swagger`.

### Sample Requests

#### Create a Blog Post

```sh
POST /api/blogs
Content-Type: application/json

{
  "name": "string",
  "description": "string",
  "author": "string"
}
```

#### Get All Blog Posts

```sh
GET /api/blogs
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss what you would like to change.

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a pull request

## License

This project is licensed under the MIT License.