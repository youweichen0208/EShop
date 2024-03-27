namespace CustomerMicroservice.ApplicationCore.Contract.Repository;

public interface IUserRepositoryAsync : IBaseRepositoryAsync<User>
{
    Task<bool> Login(string username, string password);

    Task<User?> FindByEmail(string email);
}