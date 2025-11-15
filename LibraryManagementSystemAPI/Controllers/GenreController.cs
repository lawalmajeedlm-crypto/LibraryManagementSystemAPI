using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genres;

        public GenreController(IGenreRepository genres)
        {
            _genres = genres;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll()
        {
            var genres = await _genres.GetAllAsync();
            return Ok(genres);
        }

        // GET: api/genres/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Genre>> GetById(Guid id)
        {
            var genre = await _genres.GetByIdAsync(id);
            if (genre is null) return NotFound();
            return Ok(genre);
        }

        // GET: api/genres/{id}/books
        [HttpGet("{id:guid}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(Guid id)
        {
            var books = await _genres.GetBooksByGenreAsync(id);
            return Ok(books);
        }

        // POST: api/genres
        [HttpPost]
        public async Task<ActionResult<Genre>> Create(Genre genre)
        {
            await _genres.AddAsync(genre);
            var saved = await _genres.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to save genre.");
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
        }

        // PUT: api/genres/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Genre genre)
        {
            if (id != genre.Id) return BadRequest();

            _genres.Update(genre);
            var saved = await _genres.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to update genre.");
            return NoContent();
        }

        // DELETE: api/genres/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genres.GetByIdAsync(id);
            if (genre is null) return NotFound();

            _genres.Remove(genre);
            var saved = await _genres.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to delete genre.");
            return NoContent();
        }
    }
}
