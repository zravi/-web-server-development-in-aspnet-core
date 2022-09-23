using System;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;

namespace MovieCharactersEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movieObj1 = new Movie()
            {
                // Id = 1,
                Title = "King Kong",
                Director = "Peter Jackson",
                ReleaseYear = 2005,
                Genre = "Action",
                Picture = "https://m.media-amazon.com/images/M/MV5BMjYxYmRlZWYtMzAwNC00MDA1LWJjNTItOTBjMzlhNGMzYzk3XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                Trailer = "https://www.youtube.com/watch?v=AYaTCPbYGdk"
            };
            
            Movie movieObj2 = new Movie()
            {
                // Id = 1,
                Title = "Godzilla vs. Kong",
                Director = "Adam Wingard",
                ReleaseYear = 2021,
                Genre = "Action",
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/6/63/Godzilla_vs._Kong.png/220px-Godzilla_vs._Kong.png"
            };

            Character characterObj1 = new Character()
            {
                FullName = "King Kong",
                Alias = "The 8th Wonder of the World",
                Gender = "Male",
                Picture = "https://upload.wikimedia.org/wikipedia/en/6/6a/Kingkong_bigfinal1.jpg"
            };
            
            Character characterObj2 = new Character()
            {
                FullName = "Ann Darrow",
                Gender = "Female",
                Picture = "https://www.commonsensemedia.org/sites/default/files/styles/ratio_16_9_small/public/screenshots/csm-movie/king-kong-2005-ss3.jpg"
            };

            Franchise franchiseObj = new Franchise()
            {
                Name = "King Kong Franchise",
                Description = "All movies with King Kong as the main antagonist."
            };

            using (MovieManagerDbContext context = new MovieManagerDbContext())
            {
                context.Franchise.Add(franchiseObj);
                context.Movie.Add(movieObj1);
                context.Movie.Add(movieObj2);
                context.Character.Add(characterObj1);
                context.Character.Add(characterObj2);
                context.SaveChanges();
            }
        }
    }
}
