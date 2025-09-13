namespace InMemoryRepositories;

using RepositoryContracts;
using Model;
public class CommentInMemoryRepository : ICommentRepository {
    private List<Comment> comments = [];
    public Task<Comment> AddAsync(Comment comment) {
        comment.Id = comments.Count != 0
            ? comments.Max(p => p.Id) + 1 
            : 1;
        comments.Add(comment);

        return Task.FromResult(comment);
    }

    public Task DeleteAsync(int id) {
        Comment? postToRemove = comments.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");
            
        comments.Remove(postToRemove);

        return Task.CompletedTask;
    }

    public IQueryable<Comment> GetManyAsync() {
        return comments.AsQueryable();
    }

    public Task<Comment> GetSingleAsync(int id) {
        Comment? comment = comments.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");
            
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment) {
        Comment? existingComment = comments.SingleOrDefault(p => p.Id == comment.Id)
            ?? throw new InvalidOperationException($"Comment with ID '{comment.Id}' not found.");
            
        comments.Remove(existingComment);
        comments.Add(comment);

        return Task.CompletedTask;
    }
}
