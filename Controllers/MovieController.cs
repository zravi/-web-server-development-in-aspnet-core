using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersEFCodeFirst.DTO.Movie;
using MovieCharactersEFCodeFirst.Models.Domain;
using MovieCharactersEFCodeFirst.Models.DTO.Movie;
using MovieCharactersEFCodeFirst.Services;

namespace MovieCharactersEFCodeFirst.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MovieController(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        #region Generic CRUD

        /// <summary>
        /// Get a list of all movies.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetAllMoviesAsync());
        }

        /// <summary>
        /// Get a movie by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            Movie movie = await _movieService.GetSpecificMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Update a movie by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
            {
                return BadRequest();
            }

            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            await _movieService.UpdateMovieAsync(domainMovie);
            return NoContent();
        }

        /// <summary>
        /// Insert a new movie.
        /// </summary>
        /// <param name="dtoMovie"></param>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            domainMovie = await _movieService.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// Delete a movie by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

        #endregion

        #region Update movie related information

        /// <summary>
        /// Insert characters to a movie by ID.
        /// </summary>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> characters)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            try
            {
                await _movieService.UpdateMovieCharactersAsync(id, characters);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character");
            }

            return NoContent();
        }

        #endregion
    }
}