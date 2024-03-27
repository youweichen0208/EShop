namespace CustomerMicroservice.ApplicationCore.Contract.Service;

public interface IUserServiceAsync
{
    Task<User?> Authenticate(string username, string password);
    Task<User?> GetCustomerByEmail(string email);
    Task<IEnumerable<User>> GetAllCustomers();
    Task<User> CreateCustomer(User user);
    Task UpdateCustomer(User user);
    Task DeleteCustomer(int id);
}