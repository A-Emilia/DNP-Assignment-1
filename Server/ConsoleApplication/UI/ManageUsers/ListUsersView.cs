using System;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public class ListUsersView {
    private readonly IUserRepository userRepository;
    public ListUsersView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }
}
