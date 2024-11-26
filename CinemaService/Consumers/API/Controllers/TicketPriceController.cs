using Application.TicketPrices.Dtos;
using Application.TicketPrices.Ports;
using Application.TicketPrices.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/ticket-prices")]
    public class TicketPriceController : ControllerBase
    {
        private readonly ITicketPriceManager _ticketPriceManager;

        public TicketPriceController(ITicketPriceManager ticketPriceManager)
        {
            _ticketPriceManager = ticketPriceManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketPriceDto>>> GetAll()
        {
            var prices = await _ticketPriceManager.GetAllAsync();
            return Ok(prices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketPriceDto>> GetById(int id)
        {
            var price = await _ticketPriceManager.GetByIdAsync(id);
            if (price == null)
            {
                return NotFound(new { Error = "Ticket price not found." });
            }

            return Ok(price);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateTicketPriceRequest request)
        {
            await _ticketPriceManager.AddAsync(request);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTicketPriceRequest request)
        {
            try
            {
                await _ticketPriceManager.UpdateAsync(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Error = "Ticket price not found." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            try
            {
                await _ticketPriceManager.DeactivateAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Error = "Ticket price not found." });
            }
        }
    }
}
