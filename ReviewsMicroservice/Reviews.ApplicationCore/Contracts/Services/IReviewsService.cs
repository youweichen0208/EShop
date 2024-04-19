namespace Reviews.ApplicationCore.Contracts.Services;
using Reviews.ApplicationCore.Entities;
public interface IReviewsService
{
    Task<List<Reviews>?> GetReviewsByProduct(int productId);
    Task<Reviews> CreateReview(Reviews reviews);
}