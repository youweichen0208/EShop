namespace ApplicationCore.Contracts;

public interface IBaseRepository<T> where T:class
{
    T Add(T entity);
    int Update(T entity);
    int Delete(int id);

    IEnumerable<T> GetAll();

    T? GetById(int id);
}