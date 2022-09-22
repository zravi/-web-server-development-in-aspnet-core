1. Install following NuGet packages:
   * Microsoft.EntityFrameworkCore.SqlServer 
   * Microsoft.EntityFrameworkCore.Tools
2. Create DB Context (MovieManagerDbContext.cs)
3. Create Models (MovieCharacter.cs etc)
4. Connection string (MovieManagerDbContext.cs -> OnConfiguring)
5. Add migration: 
   * NuGet Package Manager Console -> "add-migration InitialDB"
   OR
   * Dotnet CLI -> "dotnet ef migrations add InitialDB"
6. If new models have been created or new parameters are added to existing ones, 
    run command from 5th again but change the database name, e.g. add-migration AddedMovieCharactersTable
7. Run migration:
   * NuGet Package Manager Console -> "update-database"
     OR
   * Dotnet CLI -> "dotnet ef database update"