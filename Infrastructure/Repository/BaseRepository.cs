using ApplicationCore.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ShippingDbContext _shippingDbContext;

    public BaseRepository(ShippingDbContext context)
    {
        _shippingDbContext = context;
    }
    public int Add(T entity)
    {
        _shippingDbContext.Set<T>().Add(entity);
        return _shippingDbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }
}