using Application.Responses;
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

        /// <summary>
        /// Obtém os detalhes de um usuário pelo ID.
        /// </summary>
        /// <param name="id">O identificador único do usuário.</param>
        /// <returns>Detalhes do usuário ou NotFound caso não exista.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> Get(int id)
        {
            var response = await _userManager.GetUserByIdAsync(id);

            if (response != null)
                return Ok(response);

            return NotFound();
        }

        /// <summary>
        /// Cria um novo usuário com os dados fornecidos.
        /// </summary>
        /// <param name="request">Os dados necessários para criar o usuário.</param>
        /// <returns>Os detalhes do usuário criado ou BadRequest em caso de falha.</returns>
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
    }
}
