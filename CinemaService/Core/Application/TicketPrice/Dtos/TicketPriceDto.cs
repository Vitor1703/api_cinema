namespace Application.TicketPrices.Dtos
{
    public class TicketPriceDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public TicketPriceDto(Domain.TicketPrices.Entities.TicketPrice ticketPrice)
        {
            Id = ticketPrice.Id;
            Price = ticketPrice.Price;
            CreatedAt = ticketPrice.CreatedAt;
            UpdatedAt = ticketPrice.UpdatedAt;
            IsActive = ticketPrice.IsActive;
        }
    }
}
