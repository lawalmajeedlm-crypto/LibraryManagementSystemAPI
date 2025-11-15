using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId);
    }
}
