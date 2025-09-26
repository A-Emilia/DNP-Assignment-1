using Model;
using RepositoryContracts;

namespace FileRepository;

public class UserRepository : IUserRepository {

    private readonly String filePath = "user.json";

    public UserRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, []);
    }

    public User Add(User user) {
        throw new NotImplementedException();
    }

    public Task<User> AddAsync(User User) {
        throw new NotImplementedException();
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetManyAsync() {
        throw new NotImplementedException();
    }

    public User GetSingle(int id) {
        throw new NotImplementedException();
    }

    public Task<User> GetSingleAsync(int id) {
        throw new NotImplementedException();
    }

    public void Update(User user) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User User) {
        throw new NotImplementedException();
    }
}
