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
using MovieCharactersEFCodeFirst.Models;
using MovieCharactersEFCodeFirst.Models.Domain;
using MovieCharactersEFCodeFirst.Models.DTO.Franchise;

namespace MovieCharactersEFCodeFirst.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieManagerDbContext _context;
        private readonly IMapper _mapper;

        public FranchisesController(MovieManagerDbContext context, IMapper imapper)
        {
            _context = context;
            _mapper = imapper;
        }

        /// <summary>
        /// Get a list of all franchises.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(
                await _context.Franchises
                    .Include(f => f.Movies)
                    .ToListAsync()
            );
        }

        /// <summary>
        /// Get a franchise by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises.Include(f => f.Movies)
                .FirstOrDefaultAsync(f => f.Id == id);
            
            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseReadDTO>(franchise);
        }

        /// <summary>
        /// Update a franchise by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO franchiseDTO)
        {
            if (id != franchiseDTO.Id)
            {
                return BadRequest();
            }

            // Map to domain
            Franchise domainFranchise = _mapper.Map<Franchise>(franchiseDTO);
            _context.Entry(domainFranchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Insert a new franchise.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
          if (_context.Franchises == null)
          {
              return Problem("Entity set 'MovieManagerDbContext.Franchise'  is null.");
          }
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        /// <summary>
        /// Delete a franchise by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        /// <summary>
        /// Insert movies to a franchise by ID.
        /// </summary>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id, List<int> movies)
        {
            if (!FranchiseExists(id))
            {
                return NotFound();
            }

            try
            {
                Franchise franchiseToUpdateCharacters = await _context.Franchises
                    .Include(f => f.Movies)
                    .Where(f => f.Id == id)
                    .FirstAsync();

                List<Movie> addedMovies = new();
                foreach (var movieId in movies)
                {
                    Movie m = await _context.Movies.FindAsync(movieId);
                    if (m == null)  // Doesn't exist
                    {
                        throw new KeyNotFoundException();
                    }

                    addedMovies.Add(m);
                }

                franchiseToUpdateCharacters.Movies = addedMovies;
                await _context.SaveChangesAsync();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character");
            }

            return NoContent();
        }
        

        private bool FranchiseExists(int id)
        {
            return (_context.Franchises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
