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

    public async Task<User> AddAsync(User user) {
        List<User> users = await GetRepositoryAsync();
        int maxId = users.Count() > 0 ? users.Max(c => c.Id) : 1;
        user.Id = maxId++;
        users.Add(user);
        String jsonUsers = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, jsonUsers);

        return user;
    }

    public async Task DeleteAsync(int id) {
        List<User> users = await GetRepositoryAsync();

        int toRemoveId = users.FindIndex(c => c.Id == id);
        if (toRemoveId == -1) throw new InvalidOperationException($"User with ID '{id} not found.");
        users.RemoveAt(toRemoveId);
        String jsonUsers = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, jsonUsers);
    }

    public IQueryable<User> GetManyAsync() {
        String jsonUsers = File.ReadAllTextAsync(filePath).Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(jsonUsers)!;

        return users.AsQueryable();
    }

    public async Task<User> GetSingleAsync(int id) {
        List<User> users = await GetRepositoryAsync();

        User user = users.Find(c => c.Id == id)
            ?? throw new InvalidOperationException($"User with ID '{id}' not found.");

        return user;
    }

// Cool solution, not super extensible.
//    public async Task<User> GetSingleAsync<T>(T val) {
//        List<User> users = await GetRepositoryAsync();
//
//        return val switch {
//            String name => users.Find(c => c.Name == name) ?? throw new InvalidOperationException($"User with name '{name}' not found."),
//            int id => users.Find(c => c.Id == id) ?? throw new InvalidOperationException($"User with ID '{id}' not found."),
//            _ => throw new NotImplementedException(),
//        };
//    }

    public Task UpdateAsync(User User) {
        throw new NotImplementedException();
    }

    public async Task<User> GetSingleAsync(String name) {
        List<User> users = await GetRepositoryAsync();

        User user = users.Find(c => c.Name == name)
            ?? throw new InvalidOperationException($"User with name '{name}' not found.");

        return user;
    }

    public IQueryable<User> GetManyAsync(String name) {
        String jsonUsers = File.ReadAllTextAsync(filePath).Result;
        List<User> users = JsonSerializer.Deserialize<List<User>>(jsonUsers)!;

        users = users.FindAll(c => c.Name.Contains(name))
            ?? throw new InvalidOperationException($"User with name like '{name}' not found.");

        return users.AsQueryable();
    }
}
