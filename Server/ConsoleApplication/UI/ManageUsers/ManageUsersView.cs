using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public enum ManageUserOptions {
    Create = 1,
    View_All,
}

public class ManageUsersView {
    private readonly IUserRepository userRepository;
    public ManageUsersView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }


    internal async Task OpenView() {
        while (true) {
            Console.Clear();

            Console.WriteLine("--- Manage Users ---");

            foreach (ManageUserOptions opt in Enum.GetValues<ManageUserOptions>()) {
                String desc = opt switch {
                    ManageUserOptions.Create => "1 - Create a new user.",
                    ManageUserOptions.View_All => "2 - View all users.",
                    _ => "Unhandled Option: " + opt.ToString(),
                };

                Console.WriteLine(desc);
            }

            Console.WriteLine("0 - Return to Main Menu.");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out var number)) continue;
            if (number == 0) return;
            await HandleChoice((ManageUserOptions)number);

        }
    }

        public async Task HandleChoice(ManageUserOptions choice) {
        switch (choice) {
            case ManageUserOptions.Create: {
                    Console.Clear();
                    CreateUserView userView = new(userRepository);
                    await userView.OpenView();
                    break;
                }

            case ManageUserOptions.View_All: {
                    Console.Clear();
                    ListUsersView listView = new(userRepository);
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
