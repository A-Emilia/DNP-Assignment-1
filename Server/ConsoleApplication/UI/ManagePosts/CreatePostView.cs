using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManagePosts;

public class CreatePostView(IPostRepository postRepository) {
    private readonly IPostRepository postRepository = postRepository;

    internal async Task OpenView() {
        Console.WriteLine("--- Creating Post ---");

        // TODO: SHOULD BE THE CURRENTLY LOGGED IN USER IF THAT IS ADDED
        User user = new User {
            Name = "uwu",
            Password = "uwu",
            Id = 69,
        };

        Console.WriteLine("Please enter post title.");
        String? title = Console.ReadLine();

        Console.WriteLine("Please enter content.");
        String? body = Console.ReadLine();

        Post post = new() {
            Title = title ?? "untitled",
            Body = body ?? "empty body",
            Author = user,
        };

        await postRepository.AddAsync(post);
    }
}
