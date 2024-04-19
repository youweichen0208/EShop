using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public Task<IEnumerable<Product>> GetProductsByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterProduct(Product product)
    {
        var result = await _productRepository.Add(product);
        return result != null ? true : false;
    }

    public Task<bool> DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProductById(int id)
    {
        throw new NotImplementedException();
    }
}