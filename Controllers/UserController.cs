using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Services.UserService;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken) {
            var users = await _userService.GetAllUsers(cancellationToken);
            if(users is null || users.Count == 0) {
                return NotFound("Users not exists");
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken) {
            var user = await _userService.GetUserById(id, cancellationToken);
            if(user is null) {
                return NotFound("User not exists");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO user, CancellationToken cancellationToken) {
            var result = await _userService.AddUser(user, cancellationToken);
            if(result is false) {
                return BadRequest("User already exists");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO user, CancellationToken cancellationToken) {
            var result = await _userService.UpdateUser(id, user, cancellationToken);
            if(result is false) {
                return BadRequest("User does not exists");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken) {
            var result = await _userService.DeleteUser(id, cancellationToken);
            if(result is false) {
                return BadRequest("User does not exists");
            }
            return Ok(result);
        }
    }
}