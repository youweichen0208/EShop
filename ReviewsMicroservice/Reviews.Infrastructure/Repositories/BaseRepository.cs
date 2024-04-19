using Microsoft.EntityFrameworkCore;
using Reviews.ApplicationCore.Contracts.Repositories;
using Reviews.Infrastructure.Contexts;

namespace Reviews.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    
    private readonly ReviewsDbContext _reviewsDbContext;

    public BaseRepository(ReviewsDbContext reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }
    public async Task<T> Add(T entity)
    {
        try
        {
            _reviewsDbContext.Set<T>().Add(entity);
            await _reviewsDbContext.SaveChangesAsync();
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
        _reviewsDbContext.Set<T>().Update(entity);
        return await _reviewsDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var elem = await _reviewsDbContext.Set<T>().FindAsync(id);
        if (elem != null)
            _reviewsDbContext.Set<T>().Remove(elem);

        return await _reviewsDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _reviewsDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _reviewsDbContext.Set<T>().FindAsync(id);
    }
}