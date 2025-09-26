namespace InMemoryRepositories;

using RepositoryContracts;
using Model;
public class UserInMemoryRepository : IUserRepository {
    private List<User> users = [];

    public User Add(User user) {
        throw new NotImplementedException();
    }

    public Task<User> AddAsync(User user) {
        user.Id = users.Count != 0
            ? users.Max(p => p.Id) + 1 
            : 1;
        users.Add(user);

        return Task.FromResult(user);
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        User? postToRemove = users.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"User with ID '{id}' not found.");
            
        users.Remove(postToRemove);

        return Task.CompletedTask;
    }

    public IQueryable<User> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetManyAsync() {
        return users.AsQueryable();
    }

    public User GetSingle(int id) {
        throw new NotImplementedException();
    }

    public Task<User> GetSingleAsync(int id) {
        User? user = users.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"User with ID '{id}' not found.");
            
        return Task.FromResult(user);
    }

    public void Update(User user) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user) {
        User? existingUser = users.SingleOrDefault(p => p.Id == user.Id)
            ?? throw new InvalidOperationException($"User with ID '{user.Id}' not found.");
            
        users.Remove(existingUser);
        users.Add(user);

        return Task.CompletedTask;
    }
}
