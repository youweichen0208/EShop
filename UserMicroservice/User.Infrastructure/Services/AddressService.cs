using User.ApplicationCore.Contracts.Repositories;
using User.ApplicationCore.Contracts.Services;
using User.ApplicationCore.Entities;

namespace User.Infrastructure.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<Address?> GetAddressByUserId(int id)
    {
       var address =  await _addressRepository.GetAddressByUserId(id);
       return address;
    }

    public async Task<int> UpdateAddress(Address address)
    {
        var result = await _addressRepository.Update(address);
        return result;
    }
}