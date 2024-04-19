using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Contracts.Repositories;
using User.Infrastructure.Contexts;

namespace User.Infrastructure.Repositories;
using User.ApplicationCore.Entities;
public class UserRepository : BaseRepository<User>,IUserRepository
{
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext context) : base(context)
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