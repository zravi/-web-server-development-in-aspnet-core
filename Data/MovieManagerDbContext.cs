using Microsoft.EntityFrameworkCore;
using MovieCharactersEFCodeFirst.Models;

namespace MovieCharactersEFCodeFirst.Data
{
    public class MovieManagerDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = .\SQLEXPRESS;
                                Initial Catalog=MovieManagerDB;
                                Integrated Security = true;
                                Encrypt = false;
            ");
        }
    }
}