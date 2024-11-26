using Application.Rooms.Dtos;
using Application.Rooms.Ports;
using Application.Rooms.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAll()
        {
            var rooms = await _roomManager.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetById(int id)
        {
            var room = await _roomManager.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateRoomRequest request)
        {
            await _roomManager.AddAsync(request);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRoomRequest request)
        {
            await _roomManager.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _roomManager.DeactivateAsync(id);
            return NoContent();
        }
    }
}
