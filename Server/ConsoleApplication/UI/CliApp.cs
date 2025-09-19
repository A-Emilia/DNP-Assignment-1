using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using ConsoleApplication.UI.ManagePosts;
using RepositoryContracts;

namespace ConsoleApplication.UI;

public enum CliOptions {

    ManagePosts = 1,
    ManageUsers = 2,
    ManageComments = 3,
}

public class CliApp(IUserRepository userRepository,
                    ICommentRepository commentRepository,
                    IPostRepository postRepository) {
    public IUserRepository userRepository { get; } = userRepository;
    public ICommentRepository CommentRepository { get; } = commentRepository;
    public IPostRepository PostRepository { get; } = postRepository;

    internal async Task StartAsync() {
        while (true) {
            Console.Clear();

            Console.WriteLine("--- Client Application ---");

            foreach (CliOptions opt in Enum.GetValues<CliOptions>()) {
                String desc = opt switch {
                    CliOptions.ManagePosts => "1 - Manage Posts.",
                    CliOptions.ManageUsers => "2 - Manage Users.",
                    CliOptions.ManageComments => "3 - Manage Comments.",
                    _ => "Unhandled Option: " + opt.ToString(),
                };

                Console.WriteLine(desc);
            }

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var number)) {
                continue;
            }
            
            var option = (CliOptions) number;

            await HandleChoice(option);
        }
    }

    public async Task HandleChoice(CliOptions choice) {
        switch (choice) {
            case CliOptions.ManagePosts: {
                    Console.Clear();
                    ManagePostsView postsView = new(PostRepository);
                    await postsView.OpenView();
                    break;
                }

            // Figure out a better way to do this.
            default: {
                    Console.WriteLine("Invalid option.");
                    break;
            }
        };
    }
}


