namespace InMemoryRepositories;

using RepositoryContracts;
using Model;
using System.Linq;

public class PostInMemoryRepository : IPostRepository {
    private List<Post> posts = [];

    public Post Add(Post post) {
        throw new NotImplementedException();
    }

    public Task<Post> AddAsync(Post post) {
        post.Id = posts.Count != 0
            ? posts.Max(p => p.Id) + 1 
            : 1;
        posts.Add(post);

        return Task.FromResult(post);
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Post with ID '{id}' not found.");
            
        posts.Remove(postToRemove);

        return Task.CompletedTask;
    }

    public IQueryable<Post> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<Post> GetManyAsync() {
        throw new NotImplementedException();
    }

    public Post GetSingle(int id) {
        throw new NotImplementedException();
    }

    public Task<Post> GetSingleAsync(int id) {
        Post? post = posts.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Post with ID '{id}' not found.");
            
        return Task.FromResult(post);
    }

    public void Update(Post post) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post) {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id)
            ?? throw new InvalidOperationException($"Post with ID '{post.Id}' not found.");
            
        posts.Remove(existingPost);
        posts.Add(post);

        return Task.CompletedTask;
    }
}
