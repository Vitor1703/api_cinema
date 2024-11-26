using Domain.Rooms.Entities;

namespace Application.Rooms.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }

        public RoomDto(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            Capacity = room.Capacity;
            IsActive = room.IsActive;
        }
    }
}
