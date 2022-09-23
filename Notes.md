1. Requirements:
   * Visual Studio with built-in NuGet Package Manager Console
   OR
   * Other IDE with .NET CLI and EF Core Tools installed
2. Install following NuGet packages:
   * Microsoft.EntityFrameworkCore.SqlServer
   * Microsoft.EntityFrameworkCore.Tools
3. Create DB Context (MovieManagerDbContext.cs)
4. Create Models (MovieCharacter.cs etc)
5. Connection string (MovieManagerDbContext.cs -> OnConfiguring)
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
9. ConnectionString handling instead of hardcoding:
   * Create App.Config to store ConnectionString (https://learn.microsoft.com/en-us/ef/ef6/fundamentals/configuring/connection-strings)
   * Install System.Configuration.ConfigurationManager NuGet Package
   * Usage : "string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;" 
   (https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files)
