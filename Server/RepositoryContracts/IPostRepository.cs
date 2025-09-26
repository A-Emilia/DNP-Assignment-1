namespace RepositoryContracts;

using Model;

public interface IPostRepository {
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(int id);
    IQueryable<Post> GetManyAsync();

    Post Add(Post post);
    void Update(Post post);
    void Delete(int id);
    Post GetSingle(int id);
    IQueryable<Post> GetMany();
}