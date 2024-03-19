using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly ShippingDbContext _shippingDbContext;
    public CategoryRepository(ShippingDbContext context) : base(context)
    {
        _shippingDbContext = context;
    }

    public int GetIdByName(string name)
    {
        var id = _shippingDbContext.Set<Category>().FirstOrDefault(c => c.Name == name).Id;
        return id;
    }
}