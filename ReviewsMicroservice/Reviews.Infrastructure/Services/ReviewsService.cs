using Reviews.ApplicationCore.Contracts.Repositories;
using Reviews.ApplicationCore.Contracts.Services;

namespace Reviews.Infrastructure.Services;
using Reviews.ApplicationCore.Entities;
public class ReviewsService : IReviewsService
{
    private readonly IReviewsRepository _reviewsRepository;

    public ReviewsService(IReviewsRepository reviewsRepository)
    {
        _reviewsRepository =  reviewsRepository;
    }
    
    public async Task<List<Reviews>?> GetReviewsByProduct(int productId)
    {
        var reviews = await _reviewsRepository.GetReviewsByProduct(productId);
        return reviews;
    }

    public async Task<Reviews> CreateReview(Reviews reviews)
    {
        var review = await _reviewsRepository.Add(reviews);
        return review;
    }
}