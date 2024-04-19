namespace CustomerMicroservice.ApplicationCore.Contract.Repository;

public interface IBaseRepositoryAsync<T> where T : class
{
    Task<T> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);

    Task<IEnumerable<T>> GetAll();

    Task<T?> GetById(int id);
}