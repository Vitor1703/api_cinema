namespace Application.Tickets.Requests
{
    public class CreateTicketRequest
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
