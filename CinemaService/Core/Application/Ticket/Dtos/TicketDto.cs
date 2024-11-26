using Domain.Tickets.Entities;

namespace Application.Tickets.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int SeatNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }

        public TicketDto(Ticket ticket)
        {
            Id = ticket.Id;
            SessionId = ticket.SessionId;
            UserId = ticket.UserId;
            SeatNumber = ticket.SeatNumber;
            PurchaseDate = ticket.PurchaseDate;
            Price = ticket.Price;
        }
    }
}
