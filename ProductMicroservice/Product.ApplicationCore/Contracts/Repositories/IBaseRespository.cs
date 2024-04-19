namespace ApplicationCore.Contracts.Repositories;

public interface IBaseRespository<T> where T : class
{
    Task<T?> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
}