using ProductMicroservice.ApplicationCore.Entity;

namespace ProductMicroservice.ApplicationCore.Contract.Service;

public interface IProductServiceAsync
{
    public Task<IEnumerable<Product>> GetAllProducts();
}