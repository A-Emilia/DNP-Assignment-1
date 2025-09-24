using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManagePosts;

public class ListPostView(IPostRepository postRepository) {
    private readonly IPostRepository postRepository = postRepository;

    internal async Task OpenView() {
        while (true) {
            Console.Clear();

            Console.WriteLine("--- Viewing All Posts ---");

            var res = postRepository.GetManyAsync();

            foreach (var post in res) {
                Console.WriteLine($"{post.Id} - {post.Title}\nBy: {post.Author.Name}");
                Console.WriteLine("--- --- --- --- --- ---");
            }

            Console.WriteLine("Enter a post ID to view it. Enter 0 to exit.");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var number)) continue;
            if (number == 0) return;
            if (number <= res.Count()) {
                    SinglePostView postView = new(postRepository);
                    await postView.OpenView(number);
            }
        }
    }
}
