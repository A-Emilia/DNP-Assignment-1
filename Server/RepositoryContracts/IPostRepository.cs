namespace RepositoryContracts;

using Model;

public interface IPostRepository {
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(int id);
    Task<Post> GetSingleAsync(String title);
    IQueryable<Post> GetManyAsync();
    IQueryable<Post> GetManyAsync(String title);
    IQueryable<Post> GetUserPostsAsync(String username);
}