using Application.TicketPrices.Dtos;

namespace Application.Responses
{
    public class TicketPriceResponse : Response
    {
        public TicketPriceDto Data { get; set; }

        public TicketPriceResponse(TicketPriceDto data)
        {
            Data = data;
        }
    }
}
