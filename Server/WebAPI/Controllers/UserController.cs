using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo) {
            this.userRepo = userRepo;
        }

        
    }
}
