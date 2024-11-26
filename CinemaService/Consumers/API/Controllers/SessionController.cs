using Application.Sessions.Dtos;
using Application.Sessions.Ports;
using Application.Sessions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionManager _sessionManager;

        public SessionController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetAll()
        {
            var sessions = await _sessionManager.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetByMovieId(int movieId)
        {
            var sessions = await _sessionManager.GetByMovieIdAsync(movieId);
            return Ok(sessions);
        }

        [HttpGet("room/{roomId}")]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetByRoomId(int roomId)
        {
            var sessions = await _sessionManager.GetByRoomIdAsync(roomId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSessionRequest request)
        {
            await _sessionManager.AddAsync(request);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSessionRequest request)
        {
            await _sessionManager.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _sessionManager.DeactivateAsync(id);
            return NoContent();
        }
    }
}
