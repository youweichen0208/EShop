using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IProductService
{
    public Task<List<Product>?> GetProductsByCategory(string category);
    public Task<Product?> GetProductById(int id);
    public Task<bool> RegisterProduct(Product product);
    
    public Task<List<Product>?> GetAllProducts();
    public Task<string> GetProductNameById(int id);
    
    public Task<Product?> GetProductByName(string name);
}