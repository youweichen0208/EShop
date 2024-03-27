using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class 
{
    private readonly UserDbContext _shippingDbContext;

    public BaseRepositoryAsync(UserDbContext context)
    {
        _shippingDbContext = context;
    }
    public async Task<T> Add(T entity)
    {
        _shippingDbContext.Set<T>().Add(entity);
        await _shippingDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> Update(T entity)
    {
        _shippingDbContext.Set<T>().Update(entity);
        return await _shippingDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var elem = await _shippingDbContext.Set<T>().FindAsync(id);
        if (elem != null)
           _shippingDbContext.Set<T>().Remove(elem);
        return await _shippingDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _shippingDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _shippingDbContext.Set<T>().FindAsync(id);
    }
}