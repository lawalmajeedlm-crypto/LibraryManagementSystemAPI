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
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }

        // GET: api/books/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound();

            return book;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/books/search?title=keyword
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks([FromQuery] string title)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b => b.Title.Contains(title))
                .ToListAsync();
        }

        // GET: api/books/by-author/{authorId}
        [HttpGet("by-author/{authorId:guid}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(Guid authorId)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        // GET: api/books/by-genre/{genreId}
        [HttpGet("by-genre/{genreId:guid}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(Guid genreId)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b => b.GenreId == genreId)
                .ToListAsync();
        }
    }
}
