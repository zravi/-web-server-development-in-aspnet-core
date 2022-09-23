1. Requirements:
   * Visual Studio with built-in Package Manager Console
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
   * Dotnet CLI -> "dotnet ef migrations add InitialDB"
7. If new models have been created or new parameters are added to existing ones, 
    run command from 5th again but change the database name, e.g. add-migration AddedMovieCharactersTable
8. Run migration:
   * NuGet Package Manager Console -> "update-database"
     OR
   * Dotnet CLI -> "dotnet ef database update"