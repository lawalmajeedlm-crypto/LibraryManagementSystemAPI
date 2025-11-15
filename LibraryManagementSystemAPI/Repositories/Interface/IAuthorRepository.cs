using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(Guid authorId);
    }
}
