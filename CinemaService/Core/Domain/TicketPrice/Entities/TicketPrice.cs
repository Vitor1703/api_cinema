namespace Domain.TicketPrices.Entities
{
    public class TicketPrice
    {
        public int Id { get; set; } // Identificador único
        public decimal Price { get; set; } // Preço do ingresso
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data de criação
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Data da última atualização
        public bool IsActive { get; set; } = true; // Indica se o preço está ativo
    }
}
