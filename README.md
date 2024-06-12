# Contact Database Application

This project is a CRUD (Create, Read, Update, Delete) application designed for managing a contact database. It is built using ASP.NET MVC and includes a separate unit testing project.

## Getting Started

To get a copy of the project up and running on your local machine for development and testing purposes, follow these steps:

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Microsoft SQL Server (for database)

### Installation

1. Clone the repository to your local machine.
2. Open the solution file `CRUD application 2.sln` in Visual Studio.
3. Restore the NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages".
4. Build the solution by pressing `Ctrl+Shift+B` or by selecting "Build Solution" from the "Build" menu.

## Running the Tests

The project includes a unit testing project named `UnitTestProject1`. To run the tests:

1. Open the Test Explorer in Visual Studio by going to Test > Test Explorer.
2. Click "Run All" in the Test Explorer window.

## Deployment

The project includes a GitHub Actions workflow for CI/CD that builds the application and deploys it to Azure Web Apps.

- Workflow file: [.github/workflows/master_basic-crud.yml](.github/workflows/master_basic-crud.yml)

For more information on deploying to Azure Web Apps, see the [Azure Web Apps Deploy action documentation](https://github.com/Azure/webapps-deploy).

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- Microsoft Visual Studio
- .NET Framework
- GitHub Actions for Azure