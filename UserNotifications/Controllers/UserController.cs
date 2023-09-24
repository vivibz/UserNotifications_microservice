using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<User>>> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok(await _userService.GetById(id));
        }
    }
}
