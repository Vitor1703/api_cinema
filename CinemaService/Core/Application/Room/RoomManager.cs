using Application.Rooms.Dtos;
using Application.Rooms.Ports;
using Application.Rooms.Requests;
using Domain.Rooms.Entities;
using Domain.Rooms.Ports;

namespace Application.Rooms
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Select(r => new RoomDto(r));
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return room != null ? new RoomDto(room) : null;
        }

        public async Task AddAsync(CreateRoomRequest request)
        {
            var room = new Room
            {
                Name = request.Name,
                Capacity = request.Capacity,
                IsActive = true
            };

            await _roomRepository.AddAsync(room);
        }

        public async Task UpdateAsync(int id, UpdateRoomRequest request)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                throw new KeyNotFoundException("Room not found");
            }

            room.Name = request.Name;
            room.Capacity = request.Capacity;

            await _roomRepository.UpdateAsync(room);
        }

        public async Task DeactivateAsync(int id)
        {
            await _roomRepository.DeactivateAsync(id);
        }
    }
}
