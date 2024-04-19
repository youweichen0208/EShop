using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IProductRepository : IBaseRespository<Product>
{
    Task<List<Product>?> GetProductsByCategory(string category);
    Task<Product?> GetProductByName(string name);
}