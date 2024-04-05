namespace CustomerMicroservice.ApplicationCore.Contract.Service;

public interface IUserServiceAsync
{
    Task<User?> Authenticate(string username, string password);
    Task<User?> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}