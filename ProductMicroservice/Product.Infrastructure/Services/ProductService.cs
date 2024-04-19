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
    
    public Task<List<Product>?> GetProductsByCategory(string category)
    {
       var products =  _productRepository.GetProductsByCategory(category);
       return products;
    }
    
    public async Task<Product?> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        return product;
    }

    public async Task<bool> RegisterProduct(Product product)
    {
        var result = await _productRepository.Add(product);
        return result != null ? true : false;
    }

    public async Task<List<Product>?> GetAllProducts()
    {
        var products = await _productRepository.GetAll();
        return products?.ToList();
    }
    

    public async Task<string> GetProductNameById(int id)
    {
       var product= await _productRepository.GetById(id);
       if (product != null)
           return product.Name;
       else
           return "";
    }

    public async Task<Product?> GetProductByName(string name)
    {
        var product = await _productRepository.GetProductByName(name);
        return product;
    }
}