using System.Text.Json;
using System.Threading.Tasks;
using Model;
using RepositoryContracts;

namespace FileRepository;

public class UserRepository : IUserRepository {

    private async Task<List<User>> GetRepositoryAsync() {
        String jsonUsers = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<User>>(jsonUsers)!;
    }

    private readonly String filePath = "users.json";

    public UserRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
    }

    public User Add(User user) {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User user) {
        List<User> users = await GetRepositoryAsync();
        int maxId = users.Count() > 0 ? users.Max(c => c.Id) : 1;
        user.Id = maxId++;
        users.Add(user);
        String jsonUsers = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, jsonUsers);

        return user;
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id) {
        List<User> users = await GetRepositoryAsync();

        int toRemoveId = users.FindIndex(c => c.Id == id);
        if (toRemoveId == -1) throw new InvalidOperationException($"User with ID '{id} not found.");
        users.RemoveAt(toRemoveId);
        String jsonUsers = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, jsonUsers);
    }

    public IQueryable<User> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetManyAsync() {
        String jsonUsers = File.ReadAllTextAsync(filePath).Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(jsonUsers)!;

        return users.AsQueryable();
    }

    public User GetSingle(int id) {
        throw new NotImplementedException();
    }

    public async Task<User> GetSingleAsync(int id) {
        List<User> users = await GetRepositoryAsync();

        User user = users.Find(c => c.Id == id)
            ?? throw new InvalidOperationException($"User with ID '{id}' not found.");

        return user;
    }

    public void Update(User user) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User User) {
        throw new NotImplementedException();
    }
}
