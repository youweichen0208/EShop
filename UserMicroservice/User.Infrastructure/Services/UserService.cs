using User.ApplicationCore.Contracts.Repositories;
using User.ApplicationCore.Contracts.Services;

namespace User.Infrastructure.Services;
using User.ApplicationCore.Entities;
public class UserService: IUserService
{
    private readonly IUserRepository _userRepositoryAsync;

    public UserService(IUserRepository userRepositoryAsync)
    {
        _userRepositoryAsync = userRepositoryAsync;
    }


    public async Task<User?> Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> Login(string email)
    {
        var user = await _userRepositoryAsync.GetUserByEmail(email);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _userRepositoryAsync.GetAll();
        return users;
    }

    public async Task<User> CreateUser(User user)
    {
        var result = await _userRepositoryAsync.Add(user);
        return result;
    }

    public async Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserById(int id)
    {
        var user = await _userRepositoryAsync.GetById(id);
        return user;
    }
}