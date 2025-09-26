namespace RepositoryContracts;

using Model;

public interface ICommentRepository {
    Task<Comment> AddAsync(Comment Comment);
    Task UpdateAsync(Comment Comment);
    Task DeleteAsync(int id);
    Task<Comment> GetSingleAsync(int id);
    IQueryable<Comment> GetManyAsync();

    Comment Add(Comment comment);
    void Update(Comment comment);
    void Delete(int id);
    Comment GetSingle(int id);
    IQueryable<Comment> GetMany();
}