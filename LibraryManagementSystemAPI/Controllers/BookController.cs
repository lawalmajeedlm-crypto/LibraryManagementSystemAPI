using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _books;

        public BookController(IBookRepository books)
        {
            _books = books;
        }

        // GET: api/books?page=1&pageSize=10&search=keyword
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var (items, total) = await _books.GetPagedAsync(page, pageSize, search);

            Response.Headers.Append("X-Total-Count", total.ToString());
            return Ok(items);
        }

        // GET: api/books/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Book>> GetById(Guid id)
        {
            var book = await _books.GetDetailedByIdAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            await _books.AddAsync(book);
            var saved = await _books.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to save book.");
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Book book)
        {
            if (id != book.Id) return BadRequest();

            _books.Update(book);
            var saved = await _books.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to update book.");
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _books.GetByIdAsync(id);
            if (book is null) return NotFound();

            _books.Remove(book);
            var saved = await _books.SaveChangesAsync();
            if (!saved) return StatusCode(500, "Failed to delete book.");
            return NoContent();
        }

        // GET: api/books/search?title=xyz
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> Search([FromQuery] string title)
        {
            var results = await _books.FindAsync(b => b.Title.Contains(title));
            return Ok(results);
        }

        // GET: api/books/by-author/{authorId}
        [HttpGet("by-author/{authorId:guid}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetByAuthor(Guid authorId)
        {
            var results = await _books.GetByAuthorAsync(authorId);
            return Ok(results);
        }

        // GET: api/books/by-genre/{genreId}
        [HttpGet("by-genre/{genreId:guid}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetByGenre(Guid genreId)
        {
            var results = await _books.FindAsync(b => b.GenreId == genreId);
            return Ok(results);
        }
    }
}
