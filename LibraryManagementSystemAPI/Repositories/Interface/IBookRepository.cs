using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<(IEnumerable<Book> Items, int Total)> GetPagedAsync(int page, int pageSize, string? search);
        Task<IEnumerable<Book>> GetByAuthorAsync(Guid authorId);
        Task<Book?> GetDetailedByIdAsync(Guid id);
    }
}
