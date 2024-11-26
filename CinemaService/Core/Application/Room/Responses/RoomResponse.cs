using Application.Rooms.Dtos;

namespace Application.Responses
{
    public class RoomResponse : Response
    {
        public RoomDto Data { get; set; }

        public RoomResponse(RoomDto data)
        {
            Data = data;
        }
    }
}
