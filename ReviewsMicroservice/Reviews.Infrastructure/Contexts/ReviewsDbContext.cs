using Microsoft.EntityFrameworkCore;

namespace Reviews.Infrastructure.Contexts;
using Reviews.ApplicationCore.Entities;
public class ReviewsDbContext : DbContext
{
    public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options) : base(options)
    {
        
    }
    private DbSet<Reviews> Reviews { get; set; }
}