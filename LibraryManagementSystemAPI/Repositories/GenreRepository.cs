using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly LibraryContext _context;
        public GenreRepository(LibraryContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId) =>
            await _context.Books
                .Where(b => b.GenreId == genreId)
                .Include(b => b.Author)
                .ToListAsync();
    }
}
