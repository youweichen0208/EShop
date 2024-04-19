
using Microsoft.EntityFrameworkCore;

namespace Reviews.Infrastructure.Repositories;
using Reviews.ApplicationCore.Entities;
using Reviews.ApplicationCore.Contracts.Repositories;
using Reviews.Infrastructure.Contexts;
public class ReviewsRepository : BaseRepository<Reviews>, IReviewsRepository
{
    private readonly ReviewsDbContext _reviewsDbContext;

    public ReviewsRepository(ReviewsDbContext reviewsDbContext) : base(reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<List<Reviews>?> GetReviewsByProduct(int id)
    {
        var reviews =await _reviewsDbContext.Set<Reviews>().Where(review => review.ProductId == id).OrderByDescending(review => review.Time).ToListAsync();
        return reviews;
    }
}