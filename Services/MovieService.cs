using Microsoft.EntityFrameworkCore;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models.Domain;

namespace MovieCharactersEFCodeFirst.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieManagerDbContext _context;

        public MovieService(MovieManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Characters)
                .ToListAsync();
        }

        public async Task<Movie> GetSpecificMovieAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieCharactersAsync(int movieId, List<int> characters)
        {
            Movie movieToUpdateCharacters = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.Id == movieId)
                .FirstAsync();

            List<Character> chars = new();
            foreach (var characterId in characters)
            {
                Character c = await _context.Characters.FindAsync(characterId);
                if (c == null)  // Doesn't exist
                {
                    throw new KeyNotFoundException();
                }

                chars.Add(c);
            }

            movieToUpdateCharacters.Characters = chars;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }
    }
}