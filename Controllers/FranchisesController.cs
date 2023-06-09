using System.Net.Mime;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Domain;
using MovieCharactersEFCodeFirst.DTO.Franchise;

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
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO dtoFranchise)
        {
            if (_context.Franchises == null)
            {
                return Problem("Entity set 'MovieManagerDbContext.Franchises' is null.");
            }

            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            _context.Franchises.Add(domainFranchise);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id }, domainFranchise);
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

            var franchise = await _context.Franchises.Include(f => f.Movies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            // Remove movies from franchise before attempting to delete franchise.
            foreach (var movie in franchise.Movies)
            {
                franchise.Movies.Remove(movie);
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
        
        // /// <summary>
        // /// Get a list of characters in franchises.
        // /// </summary>
        // [HttpGet]
        // [Route("franchisecharacters")]
        // public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetCharactersInFranchises()
        // {
        //     var franchiseList =
        //         (from f in _context.Franchises
        //             join m in _context.Movies on f.Id equals m.FranchiseId
        //         join c in _context.Characters on m.Id equals cm.MovieId
        //         join c in _context.Characters on cm.CharacterId equals c.Id
        //         select new FranchiseCharactersReadDTO()
        //         {
        //             FranchiseId = f.Id,
        //             FranchiseName = f.Name,
        //             CharacterName = c.FullName
        //         }).ToList();
        //     
        //     return franchiseList;
        //
        //     return _mapper.Map<List<FranchiseReadDTO>>(
        //         await _context.Franchises
        //             .Include(f => f.Movies)
        //             .ToListAsync()
        //     );
        // }
        

        private bool FranchiseExists(int id)
        {
            return (_context.Franchises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
