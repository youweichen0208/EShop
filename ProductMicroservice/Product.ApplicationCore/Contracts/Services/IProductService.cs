using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetProductsByCategory(string category);
    public Task<Product> GetProductById(int id);
    public Task<bool> RegisterProduct(Product product);
    public Task<bool> DeleteProduct(Product product);
    public Task<bool> UpdateProductById(int id);
}