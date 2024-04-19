using Microsoft.EntityFrameworkCore;
using User.ApplicationCore.Contracts.Repositories;
using User.ApplicationCore.Entities;
using User.Infrastructure.Contexts;

namespace User.Infrastructure.Repositories;

public class AddressRepository: BaseRepository<Address>,IAddressRepository
{
    private readonly UserDbContext _userDbContext;
    public AddressRepository(UserDbContext context) : base(context)
    {
        _userDbContext = context;
    }

    public Task<Address?> GetAddressByUserId(int id)
    {
        var address = _userDbContext.Set<Address>().FirstOrDefaultAsync(address => address.UserId == id);
        return address;
    }
}