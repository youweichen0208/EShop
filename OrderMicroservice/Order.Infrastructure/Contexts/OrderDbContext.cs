using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure.Contexts;
using ApplicationCore.Entities;
public class DbContext : Db
{
    
    
    private DbSet<Order> Orders { get; set; }
}