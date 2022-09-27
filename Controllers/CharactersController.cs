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
using MovieCharactersEFCodeFirst.DTO.Character;
using MovieCharactersEFCodeFirst.Models;
using MovieCharactersEFCodeFirst.Models.Domain;

namespace MovieCharactersEFCodeFirst.Controllers
{
    [Route("api/characters")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly MovieManagerDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MovieManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of all characters.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _context.Characters.ToListAsync());
        }

        /// <summary>
        /// Get a character by ID.
        /// </summary>
        [HttpGet("{id}", Name = "Example")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<CharacterReadDTO>(character);
        }

        /// <summary>
        /// Update a character by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO characterDTO)
        {
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }

            // Map to domain
            Character domainCharacter = _mapper.Map<Character>(characterDTO);
            _context.Entry(domainCharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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
        /// Insert a new character.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'MovieManagerDbContext.Character' is null.");
            }

            Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
            _context.Characters.Add(domainCharacter);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCharacter", new { id = domainCharacter.Id }, domainCharacter);
        }

        /// <summary>
        /// Delete a character by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}