using System;
using Model;
using RepositoryContracts;

namespace ConsoleApplication.UI.ManageUsers;

public class ManageUsersView {
    private readonly IUserRepository userRepository;
    public ManageUsersView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }
}
