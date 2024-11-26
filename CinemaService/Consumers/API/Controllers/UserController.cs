using Application.Responses;
using Application.Users.Dtos;
using Application.Users.Ports;
using Application.Users.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(
            ILogger<UserController> logger,
            IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> Get(int id)
        {
            var response = await _userManager.GetUserByIdAsync(id);

            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Post(CreateUserRequest request)
        {
            try
            {
                var response = await _userManager.CreateUserAsync(request);
                return Created("", response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userManager.LoginAsync(request);
                return Ok(user);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }
    }
}
