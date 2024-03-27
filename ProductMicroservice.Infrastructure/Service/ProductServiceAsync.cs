using ProductMicroservice.ApplicationCore.Contract.Repository;
using ProductMicroservice.ApplicationCore.Contract.Service;
using ProductMicroservice.ApplicationCore.Entity;

namespace ProductMicroservice.Infrastructure.Service;

public class ProductServiceAsync : IProductServiceAsync
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    public ProductServiceAsync(IProductRepositoryAsync productRepositoryAsync)
    {
        _productRepositoryAsync = productRepositoryAsync;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
       return await _productRepositoryAsync.GetAll();
    }
}