using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystemAPI.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _Set;
    public Repository(LibraryContext context)
    {
        _context = context;
        _Set = context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAllAsync() => await _Set.ToListAsync();
    public async Task<T?> GetByIdAsync(Guid id) => await _Set.FindAsync(id);
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _Set.Where(predicate).ToListAsync();
    public async Task AddAsync(T entity) => await _Set.AddAsync(entity);

    public void Update(T entity) => _Set.Update(entity);
    public void Remove(T entity) => _Set.Remove(entity);
    public async Task<bool> SaveChangeAsync()
    { 
    return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}



