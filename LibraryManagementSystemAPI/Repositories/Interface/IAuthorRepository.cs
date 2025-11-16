using LibraryManagementSystemAPI.Models;

namespace LibraryManagementSystemAPI.Repository.Interface
{
    public interface IAuthorRepository 
    {
        Task<IEnumerable<Author>> GetAllAsyc();
        Task<Author?> GetByIdAsync(Guid id);
    }
}
