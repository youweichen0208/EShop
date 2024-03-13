using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;


public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private ShippingDbContext _shippingDbContext;
    public CustomerRepository(ShippingDbContext context) : base(context)
    {
        _shippingDbContext = context;
    }

    public bool Login(string username, string password)
    {
        var user = _shippingDbContext.Customers.SingleOrDefault(customer =>
            customer != null && customer.Email == username && customer.Password == password);
        return user != null ? true : false;
    }

    public Customer? FindByEmail(string email)
    {
        return _shippingDbContext.Customers.SingleOrDefault(customer => customer.Email == email);
    }
}