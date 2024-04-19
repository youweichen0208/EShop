namespace User.ApplicationCore.Contracts.Repositories;

using User.ApplicationCore.Entities;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmail(string username);

    Task<User?> FindByEmail(string email);
}