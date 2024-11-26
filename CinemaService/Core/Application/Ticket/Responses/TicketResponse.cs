using Application.Tickets.Dtos;

namespace Application.Responses
{
    public class TicketResponse : Response
    {
        public TicketDto Data { get; set; }

        public TicketResponse(TicketDto data)
        {
            Data = data;
        }
    }
}
