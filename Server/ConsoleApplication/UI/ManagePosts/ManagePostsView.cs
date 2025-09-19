using System;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManagePosts;

public enum ManagePostOptions {
    Create = 1,
    View_All = 2,
}

public class ManagePostsView(IPostRepository postRepository) {
    private readonly IPostRepository postRepository = postRepository;

    public async Task OpenView() {
        while (true) {
            Console.Clear();

            Console.WriteLine("--- Manage Posts ---");

            foreach (ManagePostOptions opt in Enum.GetValues<ManagePostOptions>()) {
                String desc = opt switch {
                    ManagePostOptions.Create => "1 - Create a new post.",
                    ManagePostOptions.View_All => "2 - View all posts.",
                    _ => "Unhandled Option: " + opt.ToString(),
                };

                Console.WriteLine(desc);
            }

            Console.WriteLine("0 - Return to Main Menu.");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var number)) continue;
            if (number == 0) return;
            await HandleChoice((ManagePostOptions)number);
        }
    }


    public async Task HandleChoice(ManagePostOptions choice) {
        switch (choice) {
            case ManagePostOptions.Create: {
                    Console.Clear();
                    CreatePostView postView = new(postRepository);
                    await postView.OpenView();
                    break;
                }

            case ManagePostOptions.View_All: {
                    Console.Clear();
                    ListPostView listView = new(postRepository);
                    await listView.OpenView();
                    break;
            }
            default: {
                    Console.WriteLine("Invalid input");
                    break;
                }
        };
    }
}
