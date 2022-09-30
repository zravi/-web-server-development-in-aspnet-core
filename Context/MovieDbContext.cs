using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MovieCharactersEFCodeFirst.Domain;

namespace MovieCharactersEFCodeFirst.Data
{
    public class MovieManagerDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        // public DbSet<CharacterMovies> CharacterMovies { get; set; }

        public MovieManagerDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CreateMovies
            modelBuilder.Entity<Movie>().HasData(new Movie() {
                Id = 1, 
                Title = "Howl's Moving Castle", 
                Genre = "Anime",
                Director = "Hayao Miyazaki", 
                ReleaseYear = 2004, 
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/Howls-moving-castleposter.jpg/220px-Howls-moving-castleposter.jpg", 
                Trailer = "https://www.youtube.com/watch?v=iwROgK94zcM",
                FranchiseId = 1
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 2, 
                Title = "Spirited Away",
                Genre = "Anime",
                Director = "Hayao Miyazaki", 
                ReleaseYear = 2001, 
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/d/db/Spirited_Away_Japanese_poster.png/220px-Spirited_Away_Japanese_poster.png", 
                Trailer = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                FranchiseId = 1
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 3, 
                Title = "My Neighbor Totoro",
                Genre = "Anime",
                Director = "Hayao Miyazaki", 
                ReleaseYear = 1988, 
                Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/0/02/My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg/220px-My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg", 
                Trailer = "https://www.youtube.com/watch?v=92a7Hj0ijLs",
                FranchiseId = 1
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 4,
                Title = "Mei and the Kittenbus",
                Genre = "Anime",
                Director = "Hayao Miyazaki", 
                ReleaseYear = 2002, 
                Trailer = "https://www.youtube.com/watch?v=92a7Hj0ijLs",
                FranchiseId = 1
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 5,
                Title = "Death Note",
                Genre = "Anime",
                Director = "Adam Wingard", 
                ReleaseYear = 2017, 
                FranchiseId = 2
            });
            
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 6,
                Title = "Ghost in the Shell",
                Genre = "Anime",
                Director = "Mamoru Oshii",
                ReleaseYear = 1995
            });
            #endregion

            #region CreateCharacters
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 1, 
                FullName = "Sophie Hatter", 
                Age = 12, 
                Gender = "Female", 
                Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/5/55/Starlight_Sophie.jpg/revision/latest?cb=20210708011122"
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 2, 
                FullName = "Calcifer", 
                Alias = "Fire Demon", 
                Picture = "https://i.pinimg.com/736x/2d/ba/9a/2dba9a559e6b0a04f5086324ca96fe75.jpg"
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 3, 
                FullName = "Chihiro Ogino", 
                Age = 10, 
                Alias = "Sen", 
                Gender = "Female", 
                Picture = "https://static.wikia.nocookie.net/p__/images/9/90/Chihiro_cropped.jpg/revision/latest?cb=20220309165348&path-prefix=protagonist"
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 4, 
                FullName = "Spirit of the Kohaku River", 
                Alias = "Haku", 
                Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/3/37/Haku_Dragon_form.jpeg/revision/latest/scale-to-width-down/894?cb=20170904233228"
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 5, 
                FullName = "No-Face", 
                Alias = "Kaonashi" 
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 6, 
                FullName = "Satsuki Kusakabe",
                Age = 10,
                Picture = "https://static.wikia.nocookie.net/disney/images/b/b9/Satsuki.jpg/revision/latest?cb=20140725154339"
            });
            
            modelBuilder.Entity<Character>().HasData(new Character()
            {
                Id = 7, 
                FullName = "Totoro",
                Age = 3000,
                Gender = "Male",
                Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/d/df/Totoro_in_the_rain.png/revision/latest/scale-to-width-down/350?cb=20200831205004"
            });
            #endregion

            #region CreateFranchises
            modelBuilder.Entity<Franchise>().HasData(new Franchise()
            {
                Id = 1,
                Name = "Studio Ghibli",
                Description = "Studio Ghibli Inc. is a Japanese animation film studio based in Koganei, Tokyo. The studio is best known for its animated films and has also produced several short films, television commercials, and a television movie."
            });
            
            modelBuilder.Entity<Franchise>().HasData(new Franchise()
            {
                Id = 2,
                Name = "Madhouse",
                Description = "Madhouse Inc. is a Japanese animation studio founded in 1972 by former Mushi Pro animators, including Masao Maruyama, Osamu Dezaki, Rintaro, and Yoshiaki Kawajiri."
            });
            
            modelBuilder.Entity<Franchise>().HasData(new Franchise()
            {
                Id = 3,
                Name = "Toei Animation",
                Description = "Toei Animation Co., Ltd. is a Japanese animation studio controlled primarily by its namesake Toei Company. It has created a number of television series and movies and has adapted Japanese comics as animated series, many of which are popular around the world."
            });
            #endregion
            
            // Seed m2m character-movie. Need to define m2m and access linking table
            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Characters)
                .WithMany(m => m.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 1, CharacterId = 2 },
                            new { MovieId = 2, CharacterId = 3 },
                            new { MovieId = 2, CharacterId = 4 },
                            new { MovieId = 2, CharacterId = 5 },
                            new { MovieId = 3, CharacterId = 6 },
                            new { MovieId = 3, CharacterId = 7 },
                            new { MovieId = 4, CharacterId = 7 }
                        );
                    });
        }
    }
}