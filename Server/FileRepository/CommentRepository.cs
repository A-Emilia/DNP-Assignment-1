using System;
using System.Text.Json;
using Model;
using RepositoryContracts;

namespace FileRepository;

public class CommentRepository : ICommentRepository {
    private readonly String filePath = "comment.json";

    public CommentRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, []);
    }

    public Comment Add(Comment comment) {
        throw new NotImplementedException();
    }

    public async Task<Comment> AddAsync(Comment comment) {
        String jsonComments = await File.ReadAllTextAsync(filePath);

        // I should probably not surpress this warning.
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;
        int maxId = comments.Count() > 0 ? comments.Max(c => c.Id) : 1;
        comment.Id = maxId++;
        comments.Add(comment);
        jsonComments = JsonSerializer.Serialize(comments);

        return comment;
    }

    public void Delete(int id) {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id) {
        String jsonComments = await File.ReadAllTextAsync(filePath);

        // I should probably not surpress this warning.
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;

        int toRemoveId = comments.FindIndex(c => c.Id == id);

        if (toRemoveId == -1) throw new InvalidOperationException($"Comment with ID '{id}' not found.");

        comments.RemoveAt(toRemoveId);

        jsonComments = JsonSerializer.Serialize(comments);

        await File.WriteAllTextAsync(filePath, jsonComments);
        
        // DO I NEED TO RETURN??????
    }

    public IQueryable<Comment> GetMany() {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetManyAsync() {
        /* 
         * Technically not async, but did not want to have to change the client.
        */
        String jsonComments = File.ReadAllTextAsync(filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;
        
        return comments.AsQueryable();
    }

    public Comment GetSingle(int id) {
        throw new NotImplementedException();
    }

    public async Task<Comment> GetSingleAsync(int id) {
        String jsonComments = await File.ReadAllTextAsync(filePath);

        // I should probably not surpress this warning.
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;

        Comment comment = comments.Find(c => c.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");

        return comment;
    }

    public void Update(Comment comment) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Comment Comment) {
        throw new NotImplementedException();
    }
}
