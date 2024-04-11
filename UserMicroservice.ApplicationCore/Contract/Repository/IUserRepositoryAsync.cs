namespace CustomerMicroservice.ApplicationCore.Contract.Repository;

public interface IUserRepositoryAsync : IBaseRepositoryAsync<User>
{
    Task<User?> GetUserByEmail(string username);

    Task<User?> FindByEmail(string email);
}