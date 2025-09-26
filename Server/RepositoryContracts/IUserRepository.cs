namespace RepositoryContracts;

using Model;

public interface IUserRepository {
    Task<User> AddAsync(User User);
    Task UpdateAsync(User User);
    Task DeleteAsync(int id);
    Task<User> GetSingleAsync(int id);
    IQueryable<User> GetManyAsync();

    User Add(User user);
    void Update(User user);
    void Delete(int id);
    User GetSingle(int id);
    IQueryable<User> GetMany();
}