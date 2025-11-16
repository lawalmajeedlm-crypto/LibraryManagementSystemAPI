using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Repository
{
    public class AuthorRepository 
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId) =>
            await _context.Books
                .Where(b => b.AuthorId == authorId)
                .Include(b => b.Genre)
                .ToListAsync(); 
    }
}
