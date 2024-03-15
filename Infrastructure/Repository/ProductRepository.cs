using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly ShippingDbContext _shippingDbContext; 
    public ProductRepository(ShippingDbContext context) : base(context)
    {
        _shippingDbContext = context;
    }

    public List<Product?> pagination(int page)
    {
        int items = 5;
        return _shippingDbContext.Products.Skip((page - 1) * items).Take(5).ToList();
    }
}