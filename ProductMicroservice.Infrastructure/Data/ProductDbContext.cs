using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entity;

namespace ProductMicroservice.Infrastructure.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}