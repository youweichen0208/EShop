using ApplicationCore.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ShippingDbContext _shippingDbContext;

    public BaseRepository(ShippingDbContext context)
    {
        _shippingDbContext = context;
    }
    public T Add(T entity)
    {
        _shippingDbContext.Set<T>().Add(entity);
        _shippingDbContext.SaveChanges();
        return entity;
    }

    public int Update(T entity)
    {
        _shippingDbContext.Set<T>().Update(entity);
        return _shippingDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        var elem = _shippingDbContext.Set<T>().Find(id);
        if (elem != null)
            _shippingDbContext.Set<T>().Remove(_shippingDbContext.Set<T>().Find(id));
        return _shippingDbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _shippingDbContext.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
       return _shippingDbContext.Set<T>().Find(id);
    }
}