using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Infrastructure.Repository;

public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
{
    private readonly UserDbContext _dbContext;

    public UserRepositoryAsync(UserDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }

    public Task<User?> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }
}