namespace RepositoryContracts;

using Model;

public interface IUserRepository {
    Task<User> AddAsync(User User);
    Task UpdateAsync(User User);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetManyAsync();
}