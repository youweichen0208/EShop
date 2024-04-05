using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.ApplicationCore.Contract.Service;

namespace CustomerMicroservice.Infrastructure.Service;

public class UserServiceAsync : IUserServiceAsync
{

    private readonly IUserRepositoryAsync _userRepositoryAsync;

    public UserServiceAsync(IUserRepositoryAsync userRepositoryAsync)
    {
        _userRepositoryAsync = userRepositoryAsync;
    }
    
    
    public async Task<User?> Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
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
}