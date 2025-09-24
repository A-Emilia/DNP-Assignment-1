using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public class CreateUserView {
    private readonly IUserRepository userRepository;
    public CreateUserView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }

    internal async Task OpenView() {
        String? username = null;
        String? password = null;


        while (String.IsNullOrEmpty(username)) {
            Console.Clear();
            Console.WriteLine("Please enter username.");
            username = Console.ReadLine();
        }

        while (String.IsNullOrEmpty(password)) {
            Console.Clear();
            Console.WriteLine("Please enter password");
            password = Console.ReadLine();
        }

        User user = new() {
            Name = username,
            Password = password,
        };

        await userRepository.AddAsync(user);
    }
}
