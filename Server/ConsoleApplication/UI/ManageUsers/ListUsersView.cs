using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public class ListUsersView {
    private readonly IUserRepository userRepository;
    public ListUsersView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }

    internal async Task OpenView() {
        while (true) {
            Console.Clear();

            Console.WriteLine("--- Viewing All Users ---");

            var res = userRepository.GetManyAsync();

            foreach (var user in res) {
                Console.WriteLine($"{user.Id} - {user.Name}");
                Console.WriteLine("--- --- --- --- --- ---");
            }

            Console.WriteLine("Enter 0 to exit.");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var number)) continue;
            if (number == 0) return;
        }
    }
}
