# CRUDAPI

A .NET 9 Web API demonstrating CRUD operations for amenities, countries, and employees, backed by Microsoft SQL Server.

## Features

- Create, read, update, and delete amenities and countries
- Employee lookup and CRUD endpoints
- SQL Server data access using Dapper
- Swagger/OpenAPI documentation in the Development environment
- SQL Server schema and sample data script in [`dbscript.sql`](dbscript.sql)

## Tech stack

- C# / .NET 9
- ASP.NET Core Web API
- Microsoft SQL Server
- Dapper
- Swagger via Swashbuckle

## Prerequisites

- .NET 9 SDK
- Microsoft SQL Server
- Visual Studio, Visual Studio Code, or another .NET-compatible editor

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/midhun1988/CRUDAPI_M.git
   cd CRUDAPI_M
   ```

2. Create the database and tables by running [`dbscript.sql`](dbscript.sql) in SQL Server. The script targets a database named `HotelDB`; create that database first if it does not already exist.

3. Configure the `DefaultConnection` connection string for your SQL Server in local configuration or user secrets. Do not commit credentials or production secrets to the repository.

4. Restore dependencies and start the API:

   ```bash
   dotnet restore
   dotnet run
   ```

5. In the Development environment, open `/swagger` at the local HTTPS URL printed by `dotnet run` to explore the API.

## API endpoints

### Amenities

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/api/Amenities` | List amenities |
| `GET` | `/api/Amenities/{id}` | Get an amenity |
| `POST` | `/api/Amenities` | Create an amenity |
| `PUT` | `/api/Amenities/{id}` | Update an amenity |
| `DELETE` | `/api/Amenities/{id}` | Delete an amenity |

### Countries

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/api/Countries` | List countries |
| `GET` | `/api/Countries/{id}` | Get a country |
| `POST` | `/api/Countries` | Create a country |
| `PUT` | `/api/Countries/{id}` | Update a country |
| `DELETE` | `/api/Countries/{id}` | Delete a country |

### Employees

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/GetEmployeeDetails_Individual_CivilID?civilid={civilid}` | Find employees by civil ID |
| `GET` | `/GetEmployeeById/{id}` | Get an employee by ID |
| `POST` | `/AddEmployee` | Create an employee |
| `PUT` | `/{id}` | Update an employee |
| `DELETE` | `/{id}` | Delete an employee |

> The employee routes use the route attributes currently defined in `EmployeesController`; unlike the amenities and countries routes, they do not have a controller-level `/api/...` prefix.

## Database script and security

`dbscript.sql` creates the `Amenities`, `Countries`, `Employees`, and `tblAPIKey` tables and inserts sample records. **Review and sanitize this script before sharing or running it in any environment.** It currently includes a seeded API username/password, and its sample employee records may contain personal data. Remove or replace sensitive values and rotate any credentials that may already have been used.

## License

No license is currently specified. Unless a license is added, standard copyright restrictions apply.
