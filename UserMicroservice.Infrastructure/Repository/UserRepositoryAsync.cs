using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.Infrastructure.Context;

namespace CustomerMicroservice.Infrastructure.Repository;

public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
{
    public UserRepositoryAsync(UserDbContext context) : base(context)
    {
    }

    public Task<bool> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User?> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }
}