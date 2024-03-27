using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contract.Repository;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class 
{
    private readonly ProductDbContext _productDbContext;

    public BaseRepositoryAsync(ProductDbContext context)
    {
        _productDbContext = context;
    }
    public async Task<T> Add(T entity)
    {
        _productDbContext.Set<T>().Add(entity);
        await _productDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> Update(T entity)
    {
        _productDbContext.Set<T>().Update(entity);
        return await _productDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var elem = await _productDbContext.Set<T>().FindAsync(id);
        if (elem != null)
            _productDbContext.Set<T>().Remove(elem);
        return await _productDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _productDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _productDbContext.Set<T>().FindAsync(id);
    }
}