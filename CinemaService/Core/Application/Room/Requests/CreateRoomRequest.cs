namespace Application.Rooms.Requests
{
    public class CreateRoomRequest
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class UpdateRoomRequest
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
