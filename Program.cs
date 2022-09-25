using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;

Console.Write("Anime Movie Database");
await Execute();
Console.ReadLine();

async Task Execute()
{
    using (var db = new MovieManagerDbContext())
    {
        var movie = new Movie()
        { Title = "TestMovie", Director = "TestDirector", Genre = "TestGenre", ReleaseYear = 2000, 
            Characters = new List<Character>{new(){FullName = "TestMovieCharacter"}}};

        var franchise = new Franchise()
        {
            Name = "TestFranchiseName",
            Description = "TestFranchiseDescription",
            Movies = new List<Movie>(){movie}
        };

        db.Franchise.Add(franchise);
        await db.SaveChangesAsync();
    }
}



//
// namespace MovieCharactersEFCodeFirst
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//  
//         }
//
//         // public static IHostBuilder CreateHostBuilder(string[] args) =>
//         //     Host.CreateDefaultBuilder(args)
//         //         .ConfigureWebHostDefaults(webBuilder =>
//         //         {
//         //             webBuilder.UseStartup<Startup>();
//         //         });
//     }
// }
