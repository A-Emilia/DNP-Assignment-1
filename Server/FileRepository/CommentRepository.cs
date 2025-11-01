using System;
using System.Text.Json;
using Model;
using RepositoryContracts;

namespace FileRepository;

public class CommentRepository : ICommentRepository {

    private async Task<List<Comment>> GetRepositoryAsync() {
        String jsonComments = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;
    }
    private readonly String filePath = "comments.json";

    public CommentRepository() {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
    }

    public async Task<Comment> AddAsync(Comment comment) {
        List<Comment> comments = await GetRepositoryAsync();
        int maxId = comments.Count() > 0 ? comments.Max(c => c.Id) : 1;
        comment.Id = maxId++;
        comments.Add(comment);
        String jsonComments = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, jsonComments);

        return comment;
    }


    public async Task DeleteAsync(int id) {
        List<Comment> comments = await GetRepositoryAsync();

        int toRemoveId = comments.FindIndex(c => c.Id == id);
        if (toRemoveId == -1) throw new InvalidOperationException($"Comment with ID '{id}' not found.");
        comments.RemoveAt(toRemoveId);
        String jsonComments = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, jsonComments);
        
        // DO I NEED TO RETURN??????
    }


    public IQueryable<Comment> GetManyAsync() {
        /* 
         * Technically not async, but did not want to have to change the client.
        */
        String jsonComments = File.ReadAllTextAsync(filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;
        
        return comments.AsQueryable();
    }

    public async Task<Comment> GetSingleAsync(int id) {
        List<Comment> comments = await GetRepositoryAsync();

        Comment comment = comments.Find(c => c.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");

        return comment;
    }

    public Task UpdateAsync(Comment Comment) {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetUserCommentsAsync(String username) {
        String jsonComments = File.ReadAllTextAsync(filePath).Result;
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(jsonComments)!;

        comments = comments.FindAll(c => c.Author.Name == username)
            ?? throw new InvalidOperationException($"User with username '{username}' not found.");
        
        return comments.AsQueryable();
    }
}
