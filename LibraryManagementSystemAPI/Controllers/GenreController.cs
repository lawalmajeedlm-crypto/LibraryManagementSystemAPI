using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly LibraryContext _context;

        public GenreController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres
                .Include(g => g.Books)
                .ToListAsync();
        }

        // GET: api/genres/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id)
        {
            var genre = await _context.Genres
                .Include(g => g.Books)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
                return NotFound();

            return genre;
        }

        // POST: api/genres
        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }

        // PUT: api/genres/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            if (id != genre.Id)
                return BadRequest();

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Genres.Any(g => g.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/genres/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return NotFound();

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
