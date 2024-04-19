using User.ApplicationCore.Entities;

namespace User.ApplicationCore.Contracts.Repositories;

public interface IAddressRepository: IBaseRepository<Address>
{
    Task<Address?> GetAddressByUserId(int id);
}