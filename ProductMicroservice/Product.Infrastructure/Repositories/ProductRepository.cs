using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly ProductDbContext _productDbContext;
    public ProductRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public async Task<List<Product>?> GetProductsByCategory(string category)
    {
        var products = await _productDbContext.Set<Product>().Where(product => product.Category == category).ToListAsync();
        return products;
    }

    public async Task<Product?> GetProductByName(string name)
    {
        var product = await _productDbContext.Set<Product>().FirstOrDefaultAsync(product=>product.Name==name);
        return product;

    }
}