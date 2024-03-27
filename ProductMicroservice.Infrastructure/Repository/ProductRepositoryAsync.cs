using ProductMicroservice.ApplicationCore.Contract.Repository;
using ProductMicroservice.ApplicationCore.Entity;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repository;

public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(ProductDbContext context) : base(context)
    {
    }
}