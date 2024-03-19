using ApplicationCore.Entities;

namespace ApplicationCore.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public int GetIdByName(string name);
}