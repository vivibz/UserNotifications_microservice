using Microsoft.AspNetCore.Mvc;
using UserNotifications.Api.DTOs;
using UserNotifications.Api.Models.Request;
using UserNotifications.Api.Services.Interface;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<User>>> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserRequest request)
        {
            if (request.FullName == null)
                return BadRequest("Data Invalid");

           var createdUser = await _userService.CreateUserAsync(request.FullName);
            return new OkObjectResult(createdUser);
        }
    }
}
