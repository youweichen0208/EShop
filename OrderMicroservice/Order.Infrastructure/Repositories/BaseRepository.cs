using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.Infrastructure.Contexts;

namespace Order.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly OrderDbContext _orderDbContext;

    public BaseRepository(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }
    public async Task<T> Add(T entity)
    {
        try
        {
            _orderDbContext.Set<T>().Add(entity);
            await _orderDbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception)
        {
            // Log the exception, handle it, etc.
            return null;
        }
    }

    public async Task<int> Update(T entity)
    {
        _orderDbContext.Set<T>().Update(entity);
        return await _orderDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var elem = await _orderDbContext.Set<T>().FindAsync(id);
        if (elem != null)
            _orderDbContext.Set<T>().Remove(elem);

        return await _orderDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _orderDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _orderDbContext.Set<T>().FindAsync(id);
    }
}