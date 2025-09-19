using System;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public class CreateUserView {
    private readonly IUserRepository userRepository;
    public CreateUserView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }
}
