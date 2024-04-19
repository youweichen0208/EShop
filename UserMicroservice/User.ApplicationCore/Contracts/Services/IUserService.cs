namespace User.ApplicationCore.Contracts.Services;
using User.ApplicationCore.Entities;
public interface IUserService
{
    Task<User?> Authenticate(string username, string password);
    Task<User?> Login(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);

    Task<User?> GetUserById(int id);
}