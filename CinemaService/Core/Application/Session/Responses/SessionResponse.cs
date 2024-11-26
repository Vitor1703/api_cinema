using Application.Sessions.Dtos;

namespace Application.Responses
{
    public class SessionResponse : Response
    {
        public SessionDto Data { get; set; }

        public SessionResponse(SessionDto data)
        {
            Data = data;
        }
    }
}
