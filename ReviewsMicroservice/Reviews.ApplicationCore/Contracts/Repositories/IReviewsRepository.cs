namespace Reviews.ApplicationCore.Contracts.Repositories;
using Reviews.ApplicationCore.Entities;
public interface IReviewsRepository : IBaseRepository<Reviews>
{
    public Task<List<Reviews>?> GetReviewsByProduct(int id);
}