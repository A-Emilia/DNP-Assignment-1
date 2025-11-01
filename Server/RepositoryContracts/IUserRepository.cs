namespace RepositoryContracts;

using Model;

public interface IUserRepository {
    Task<User> AddAsync(User User);
    Task UpdateAsync(User User);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    Task<User> GetSingleAsync(String name);
    IQueryable<User> GetManyAsync();
    IQueryable<User> GetManyAsync(String name);
}