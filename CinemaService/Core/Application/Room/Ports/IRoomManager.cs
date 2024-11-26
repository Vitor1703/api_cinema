using Application.Rooms.Dtos;
using Application.Rooms.Requests;

namespace Application.Rooms.Ports
{
    public interface IRoomManager
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int id);
        Task AddAsync(CreateRoomRequest request);
        Task UpdateAsync(int id, UpdateRoomRequest request);
        Task DeactivateAsync(int id);
    }
}
