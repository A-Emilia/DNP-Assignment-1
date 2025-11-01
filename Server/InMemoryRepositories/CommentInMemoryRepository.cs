namespace InMemoryRepositories;

using RepositoryContracts;
using Model;
using System.Linq;

public class CommentInMemoryRepository {
    private List<Comment> comments = [];

    public Comment Add(Comment comment) {
        throw new NotImplementedException();
    }

    public Task<Comment> AddAsync(Comment comment) {
        comment.Id = comments.Count != 0
            ? comments.Max(p => p.Id) + 1 
            : 1;
        comments.Add(comment);

        return Task.FromResult(comment);
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        Comment? commentToRemove = comments.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");

        comments.Remove(commentToRemove);

        return Task.CompletedTask;
    }

    public IQueryable<Comment> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetManyAsync() {
        throw new NotImplementedException();
    }

    public Comment GetSingle(int id) {
        throw new NotImplementedException();
    }

    public Task<Comment> GetSingleAsync(int id) {
        Comment? comment = comments.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");
            
        return Task.FromResult(comment);
    }

    public void Update(Comment comment) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment comment) {
        Comment? existingComment = comments.SingleOrDefault(p => p.Id == comment.Id)
            ?? throw new InvalidOperationException($"Comment with ID '{comment.Id}' not found.");
            
        comments.Remove(existingComment);
        comments.Add(comment);

        return Task.CompletedTask;
    }
}
