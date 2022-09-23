using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using MovieCharactersEFCodeFirst.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MovieCharactersEFCodeFirst.Data
{
    public class MovieManagerDbContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(
                @$"{connectionString}"
            );
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Add seed data here
        //     //modelBuilder.Entity<Coach>().HasData(new Coach() { Id = 1, Name = "John McIntyre", DOB = DateTime.Now.AddYears(-40), Gender = "Male", Awards = 10 });
        //     modelBuilder.Entity<Movie>().HasData(new Movie()
        //     {
        //         Id = 1,
        //         Title = "King Kong",
        //         Director = "Peter Jackson",
        //         ReleaseYear = 2005,
        //         Genre = "Action",
        //         Picture = "https://m.media-amazon.com/images/M/MV5BMjYxYmRlZWYtMzAwNC00MDA1LWJjNTItOTBjMzlhNGMzYzk3XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
        //         Trailer = "https://www.youtube.com/watch?v=AYaTCPbYGdk"
        //     });
        //
        //     modelBuilder.Entity<Character>().HasData(new Character()
        //     {
        //         Id = 1,
        //         FullName = "King Kong",
        //         Alias = "The 8th Wonder of the World",
        //         Gender = "Male",
        //         Picture = "https://upload.wikimedia.org/wikipedia/en/6/6a/Kingkong_bigfinal1.jpg"
        //     });
        //
        //     modelBuilder.Entity<Franchise>().HasData(new Franchise()
        //     {
        //         Id = 1,
        //         Name = "King Kong Franchise",
        //         Description = "Movies with King Kong as the main villain."
        //     });
        // }
    }
}