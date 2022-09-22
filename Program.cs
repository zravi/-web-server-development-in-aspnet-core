using System;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;

namespace MovieCharactersEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movieObj = new Movie()
            {
                // Id = 1,
                Title = "King Kong",
                Director = "Peter Jackson",
                ReleaseYear = 2005,
                Genre = "Action",
                Picture = "https://m.media-amazon.com/images/M/MV5BMjYxYmRlZWYtMzAwNC00MDA1LWJjNTItOTBjMzlhNGMzYzk3XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                Trailer = "https://www.youtube.com/watch?v=AYaTCPbYGdk"
            };

            MovieCharacter characterObj = new MovieCharacter()
            {
                FullName = "King Kong",
                Alias = "The 8th Wonder of the World",
                Gender = "Male",
                Picture = "https://upload.wikimedia.org/wikipedia/en/6/6a/Kingkong_bigfinal1.jpg"
            };

            using (MovieManagerDbContext context = new MovieManagerDbContext())
            {
                context.Movies.Add(movieObj);
                context.MovieCharacters.Add(characterObj);
                context.SaveChanges();
            }
        }
    }
}
