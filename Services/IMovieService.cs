using MovieCharactersEFCodeFirst.Models.Domain;

namespace MovieCharactersEFCodeFirst.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetSpecificMovieAsync(int id);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task UpdateMovieCharactersAsync(int movieId, List<int> characters);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
    }
}