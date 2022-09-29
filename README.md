# Description
This project was created as a part of Noroff .NET Fullstack development course to learn web server development in ASP.NET Core.

The application consists of a database made in SQL Server through EF Core and a RESTful API to allow data manipulation. The database contains seed data to allow easier testing and the data can be manipulated through Swagger UI.

The database contains the following four tables: Character, Movie, CharacterMovie and Franchise.
The tables have following restictions:
- Each character can appear in multiple movies
- Each movie can include multiple different characters
- Each movie can belong to a single franchise
- Each franchise can contain multiple different movies

CharacterMovie is a link table to contain information about which characters appear in which movies

## Features
- Full CRUD for Character, Movie and Franchise tables
- Update characters in a specific movie
- Update movies in a specific franchise

## Usage
Download the repository and open the solution. The following default connection string is defined under appsettings.json:
```
    "DefaultConnection": "Data Source = .\\SQLEXPRESS; Initial Catalog=MovieDB; Integrated Security = true; Encrypt = false;"
```
Make sure that the data source matches the pattern in SMSS and that no catalog with the same name exists already. Change these values in case there are any conflicts.

To setup the database, run the following command in NuGet Package Manager Console:
```
    update-database
```

Alternatively you can use .NET CLI with EF Core tools and run the following command in terminal:
```
    dotnet ef database update
```

Once the database has been initialized, launch the program and the Swagger UI should open up in browser automatically. All available methods are listed in the UI with short descriptions about their usage. 

## Contributors
- Tuomo Kuusisto https://gitlab.com/pampula
- Laura Koivuranta https://gitlab.com/LauKoiFish


## License
[MIT](https://choosealicense.com/licenses/mit/)
