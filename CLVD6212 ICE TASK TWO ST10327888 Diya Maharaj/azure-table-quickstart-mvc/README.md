# Azure Table Quickstart - ASP.NET Core MVC (Sample)

This repository is a minimal ASP.NET Core MVC sample implementing the Microsoft Learn quickstart for writing to Azure Table / Azure Cosmos DB for Table using the `Azure.Data.Tables` SDK.

**What is included**
- Minimal MVC project files (Program.cs, Controllers, Views, Models)
- A `TableService` wrapper showing how to create/get a table and upsert/query entities
- README with run instructions

**Notes**
- Replace placeholders in `appsettings.json` with your Azure endpoint and credentials.
- This project targets .NET 7/9 style top-level statements. Adjust `TargetFramework` in the csproj if needed.

## Run locally
1. Install .NET SDK (9.0 recommended by the Learn article; .NET 7 or 8 should also work).
2. From the `src/Web` folder run:
   ```
   dotnet restore
   dotnet run
   ```
3. Open the browser at `http://localhost:5000` (or the URL shown by `dotnet run`).

## Publish to Azure
Use `azd` as described in the Microsoft Learn quickstart, or publish using VS / `dotnet publish`.
