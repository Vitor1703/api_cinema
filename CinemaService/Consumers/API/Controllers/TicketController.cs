using Application.Tickets.Dtos;
using Application.Tickets.Ports;
using Application.Tickets.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketManager _ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        [HttpGet("session/{sessionId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetBySessionId(int sessionId)
        {
            var tickets = await _ticketManager.GetBySessionIdAsync(sessionId);
            return Ok(tickets);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetByUserId(int userId)
        {
            var tickets = await _ticketManager.GetByUserIdAsync(userId);
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTicketRequest request)
        {
            try
            {
                await _ticketManager.AddAsync(request);
                return Created("", null);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _ticketManager.CancelAsync(id);
            return NoContent();
        }
    }
}
