namespace Application.TicketPrices.Requests
{
    public class CreateTicketPriceRequest
    {
        public decimal Price { get; set; } // Preço do ingresso
    }

    public class UpdateTicketPriceRequest
    {
        public decimal Price { get; set; } // Novo preço do ingresso
        public bool IsActive { get; set; } // Ativar ou desativar o preço
    }
}
