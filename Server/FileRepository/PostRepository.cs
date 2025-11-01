using System;
using System.Text.Json;
using Model;
using RepositoryContracts;

namespace FileRepository;

public class PostRepository : IPostRepository {

    private async Task<List<Post>> GetRepositoryAsync() {
        String jsonPosts = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Post>>(jsonPosts)!;
    }

    private readonly String filePath = "posts.json";

    public PostRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
    }


    public async Task<Post> AddAsync(Post post) {
        List<Post> posts = await GetRepositoryAsync();
        int maxId = posts.Count() > 0 ? posts.Max(c => c.Id) : 1;
        post.Id = maxId++;
        posts.Add(post);
        String jsonPosts = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(filePath, jsonPosts);

        return post;
    }

    public async Task DeleteAsync(int id) {
        List<Post> posts = await GetRepositoryAsync();

        int toRemoveId = posts.FindIndex(c => c.Id == id);
        if (toRemoveId == -1) throw new InvalidOperationException($"Post with ID '{id}' not found.");
        posts.RemoveAt(toRemoveId);
        String jsonPosts = JsonSerializer.Serialize(posts);
        await File.WriteAllTextAsync(filePath, jsonPosts);
    }

    public IQueryable<Post> GetManyAsync() {
        String jsonPosts = File.ReadAllTextAsync(filePath).Result;
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(jsonPosts)!;

        return posts.AsQueryable();
    }

    public async Task<Post> GetSingleAsync(int id) {
        List<Post> posts = await GetRepositoryAsync();

        Post post = posts.Find(c => c.Id == id)
            ?? throw new InvalidOperationException($"Post with ID '{id}' not found.");

        return post;
    }


    public Task UpdateAsync(Post post) {
        throw new NotImplementedException();
    }

    public async Task<Post> GetSingleAsync(String title) {
        List<Post> posts = await GetRepositoryAsync();

        Post post = posts.Find(c => c.Title == title)
            ?? throw new InvalidOperationException($"Post with title '{title}' not found.");

        return post;
    }

    public IQueryable<Post> GetManyAsync(String title) {
        String jsonPosts = File.ReadAllTextAsync(filePath).Result;
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(jsonPosts)!;

        posts = posts.FindAll(c => c.Title == title)
            ?? throw new InvalidOperationException($"Post with title '{title}' not found.");

        return posts.AsQueryable();
    }

    public IQueryable<Post> GetUserPostsAsync(String username) {
        String jsonPosts = File.ReadAllTextAsync(filePath).Result;
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(jsonPosts)!;

        posts = posts.FindAll(c => c.Author.Name == username)
            ?? throw new InvalidOperationException($"User with username '{username}' not found.");
            
        return posts.AsQueryable();
    }
}
