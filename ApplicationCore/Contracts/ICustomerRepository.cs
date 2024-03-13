using ApplicationCore.Entities;

namespace ApplicationCore.Contracts;
public interface ICustomerRepository : IBaseRepository<Customer>
{
    bool Login(string username, string password);

    Customer? FindByEmail(string email);
}