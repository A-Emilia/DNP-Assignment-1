using System.Threading.Tasks;
using DTOs;
using DTOs.UserDTOs;
using FileRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using RepositoryContracts;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo) {
            this.userRepo = userRepo;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] CreateUserDTO request) {
            try {
                await VerifyUsernameIsAvailableAsync(request.Username);

                User user = new() {
                    Name = request.Username,
                    Password = request.Password,
                };

                User created = await userRepo.AddAsync(user);
                
                UserDTO dto = new() {
                    Id = created.Id,
                    Username = created.Name,
                };

                return Created($"/user/{dto.Id}", created);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        private async Task VerifyUsernameIsAvailableAsync(string username) {
            throw new NotImplementedException();
        }

        [HttpGet]
        private async Task<ActionResult<UserDTO>> GetUser([FromBody] GetUserDTO request) {
            try {
                return request.SearchParam switch {
                    var str when int.TryParse(str, out int num) => throw new NotImplementedException(),
                    _ => throw new NotImplementedException(),
                };
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }


            async Task<UserDTO> SearchById(int Id) {
                User user = await userRepo.GetSingleAsync(Id);

                UserDTO found = new() {
                    Id = user.Id,
                    Username = user.Name,
                };

                return found;
            }
        }
    }
}
