using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Infrastructure.Context;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}