using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManagePosts;

public class SinglePostView(IPostRepository postRepository) {
    private readonly IPostRepository postRepository = postRepository;

    internal async Task OpenView(int id) {
        while (true) {
            Console.Clear();

            Post post = await postRepository.GetSingleAsync(id);

            Console.WriteLine($"--- {post.Title} - {post.Author.Name} ---");
            Console.WriteLine(post.Body);
            Console.WriteLine("--- --- --- --- --- ---");

            Console.WriteLine("Press 1 to see all comments. Enter 0 to exit.");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var number)) continue;
            if (number == 0) return;
            // Add an if to load comments.
        }
    }
}
