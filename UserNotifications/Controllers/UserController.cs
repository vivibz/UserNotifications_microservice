using Microsoft.AspNetCore.Mvc;
using UserNotifications.Models;
using UserNotifications.Repositories.Interfaces;

namespace UserNotifications.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _userRepository.GetAllUsers());
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<User>>> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok(await _userRepository.GetById(id));
        }
    }
}
