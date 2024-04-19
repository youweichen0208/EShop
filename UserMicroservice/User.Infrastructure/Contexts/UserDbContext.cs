using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Contexts;
using User.ApplicationCore.Entities;
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
}