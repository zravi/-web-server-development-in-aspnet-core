1. Requirements:
   - Visual Studio with built-in NuGet Package Manager Console
   OR
   - Other IDE with .NET CLI and EF Core Tools installed
2. Install required packages through NuGet (see below)
3. Create DB Context (MovieManagerDbContext.cs)
4. Create Models (MovieCharacter.cs etc)
5. Connection string (MovieManagerDbContext.cs -> OnConfiguring)
    * Open appsettings.json and insert the following lines:
      "AllowedHosts": "*",
      "ConnectionStrings": {
      "DefaultConnection": "Data Source = .\\SQLEXPRESS; Initial Catalog=MovieDB; Integrated Security = true; Encrypt = false;"
      }
    * In OnConfiguring method, include the following lines:
      optionsBuilder.UseSqlServer(
      configuration.GetConnectionString("DefaultConnection")
      );
6. Add migration: 
   * NuGet Package Manager Console -> "add-migration InitialDB"
   OR
   * Dotnet CLI -> "dotnet ef migrations add AddInitialDB"
7. If new models have been created or new parameters are added to existing ones, 
    run command from 6th again but change the database name, e.g. add-migration AddedMovieCharactersTable
8. Run migration:
   * NuGet Package Manager Console -> "update-database"
     OR
   * Dotnet CLI -> "dotnet ef database update"

Required packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.OpenApi
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Swashbuckle.AspNetCore

Required tools:
- NuGet Package Manager Console
OR
- DotNet CLI + EF Core Tools
