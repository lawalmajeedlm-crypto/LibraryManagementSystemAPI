using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Repository
{
    public class BookRepository 
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context) 
        {
            _context = context;
        }

        public async Task<(IEnumerable<Book> Items, int Total)> GetPagedAsync(int page, int pageSize, string? search)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim().ToLower();
                query = query.Where(b =>
                    b.Title.ToLower().Contains(s) ||
                    (b.Author!.FirstName + " " + b.Author!.LastName).ToLower().Contains(s));
            }

            var total = await query.CountAsync();
            var items = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(Guid authorId) =>
            await _context.Books
                .Where(b => b.AuthorId == authorId)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

        public async Task<Book?> GetDetailedByIdAsync(Guid id) =>
            await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
    }
}
