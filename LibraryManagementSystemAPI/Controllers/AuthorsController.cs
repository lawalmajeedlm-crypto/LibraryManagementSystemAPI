using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authors;

        public AuthorsController(IAuthorRepository authors)
        {
            _authors = authors;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            var authors = await _authors.GetAllAsync();
            return Ok(authors);
        }

        // GET: api/authors/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Author>> GetById(Guid id)
        {
            var author = await _authors.GetByIdAsync(id);
            if (author is null) return NotFound();
            return Ok(author);
        }

        // GET: api/authors/{id}/books
        [HttpGet("{id:guid}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(Guid id)
        {
            var books = await _authors.GetBooksByAuthorAsync(id);
            return Ok(books);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<Author>> Create(Author author)
        {
            await _authors.AddAsync(author);
            var saved = await _authors.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to save author.");
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Author author)
        {
            if (id != author.Id) return BadRequest();

            _authors.Update(author);
            var saved = await _authors.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to update author.");
            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _authors.GetByIdAsync(id);
            if (author is null) return NotFound();

            _authors.Remove(author);
            var saved = await _authors.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to delete author.");
            return NoContent();
        }
    }
}
