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

    public async Task<User?> GetCustomerByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllCustomers()
    {
        var customers = await _userRepositoryAsync.GetAll();
        return customers;
    }

    public async Task<User> CreateCustomer(User user)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCustomer(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }
}