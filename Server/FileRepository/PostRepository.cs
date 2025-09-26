using System;
using Model;
using RepositoryContracts;

namespace FileRepository;

public class PostRepository : IPostRepository {

    private readonly String filePath = "Post.json";

    public PostRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, []);
    }

    public Post Add(Post post) {
        throw new NotImplementedException();
    }

    public Task<Post> AddAsync(Post post) {
        throw new NotImplementedException();
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Update(Post post) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post) {
        throw new NotImplementedException();
    }
}
