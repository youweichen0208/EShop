using User.ApplicationCore.Entities;

namespace User.ApplicationCore.Contracts.Services;

public interface IAddressService
{
    Task<Address?> GetAddressByUserId(int id);

    Task<int> UpdateAddress(Address address);
}