# DotNetOpenAPI

This project is an ASP.NET Core application with integrated Swagger for API documentation.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (if you have any frontend dependencies)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other IDE of your choice

## Installation

1. **Clone the repository:**
```
git clone https://github.com/yourusername/DotNetOpenAPI.git
```
2. **Restore dependencies:**
 ```
dotnet restore
```
3. **Build the project:**
```
dotnet build --configuration Release
```
4. **Run the project:**
```
dotnet run --configuration Release
```
The application will start and listen on `http://localhost:5108` by default.

## Swagger Documentation

Swagger is used to generate API documentation. Once the application is running, you can access the Swagger UI at:
http://localhost:5108/swagger/index.html

To view OpenAPI documentation you can either use browser or download the documentation under your project as .json file.
* View via browser:
http://localhost:5108/swagger/v1/swagger.json

* Download document as swagger.json file:
In Visual Studio Terminal, run the command: curl http://localhost:5108/swagger/v1/swagger.json


## Running in GitHub Actions

This project includes a GitHub Actions workflow to build the project and generate the Swagger documentation. The workflow is defined in `.github/workflows/build-and-generate-swagger.yml`.

### Example GitHub Actions Workflow
name: Build and Generate Swagger
on: push: branches: - main pull_request: branches: - main
jobs: build: runs-on: ubuntu-latest
steps:
- name: Checkout code
  uses: actions/checkout@v2

- name: Set up .NET
  uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '8.0.x'

- name: Restore dependencies
  run: dotnet restore

- name: Build
  run: dotnet build --configuration Release

- name: Publish
  run: dotnet publish --configuration Release --output ./publish

- name: Start ASP.NET Core application
  env:
    ASPNETCORE_URLS: http://localhost:5001
  run: |
    nohup dotnet ./publish/DotNetOpenAPI.dll &
    sleep 10
    # Check if the application is running
    until curl -s http://localhost:5001/swagger/v1/swagger.json; do
      echo "Waiting for the application to start..."
      sleep 5
    done

- name: Download swagger.json
  run: curl http://localhost:5001/swagger/v1/swagger.json -o swagger.json

- name: Upload swagger.json
  uses: actions/upload-artifact@v4
  with:
    name: swagger-json
    path: swagger.json


## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
