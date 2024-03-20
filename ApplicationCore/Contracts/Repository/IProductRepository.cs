using ApplicationCore.Entities;

namespace ApplicationCore.Contracts;

public interface IProductRepository : IBaseRepository<Product>
{
    List<Product?> pagination(int page);
}