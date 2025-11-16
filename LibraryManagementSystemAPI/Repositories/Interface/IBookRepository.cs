using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interface
{
    public interface IBookRepository 
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
    }
}
