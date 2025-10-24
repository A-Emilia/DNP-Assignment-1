using System;

namespace DTOs;

public class CreateUserDTO {
    public required String Username { get; set; }
    public required String Password { get; set; }
}
