using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.DTO.Movie;
using MovieCharactersEFCodeFirst.Models;
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
        // private readonly MovieManagerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MovieController(/*MovieManagerDbContext context, */IMapper mapper, IMovieService movieService)
        {
            // _context = context;
            _mapper = mapper;
            _movieService = movieService;
        }

        #region Generic CRUD
        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetAllMoviesAsync());
            // return _mapper.Map<List<MovieReadDTO>>(await _context.Movies.Include(m => m.Characters).Include(m => m.Franchise).ToListAsync());
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            Movie movie = await _movieService.GetSpecificMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
            // if (_context.Movies == null)
            // {
            //     return NotFound();
            // }
            //   var movie = await _context.Movies.FindAsync(id);
            //
            //   if (movie == null)
            //   {
            //       return NotFound();
            //   }
            //
            //   return movie;
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

            // if (id != movie.Id)
            // {
            //     return BadRequest();
            // }
            //
            // _context.Entry(movie).State = EntityState.Modified;
            //
            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!MovieExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }
            //
            // return NoContent();
        }

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            domainMovie = await _movieService.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
            // if (_context.Movies == null)
            // {
            //     return Problem("Entity set 'MovieManagerDbContext.Movie'  is null.");
            // }
            //   _context.Movies.Add(movie);
            //   await _context.SaveChangesAsync();
            //
            //   return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
            // if (_context.Movies == null)
            // {
            //     return NotFound();
            // }
            // var movie = await _context.Movies.FindAsync(id);
            // if (movie == null)
            // {
            //     return NotFound();
            // }
            //
            // _context.Movies.Remove(movie);
            // await _context.SaveChangesAsync();
            //
            // return NoContent();
        }

        // private bool MovieExists(int id)
        // {
        //     return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
        #endregion
        
        #region Update movie related information
        
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
