using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly ProductDbContext _productDbContext;
    public ProductRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
    
}