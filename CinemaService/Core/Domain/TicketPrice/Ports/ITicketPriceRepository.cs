using Domain.TicketPrices.Entities;

namespace Domain.TicketPrices.Ports
{
    public interface ITicketPriceRepository
    {
        Task<IEnumerable<TicketPrice>> GetAllAsync(); // Listar todos os preços
        Task<TicketPrice> GetByIdAsync(int id); // Obter preço pelo ID
        Task AddAsync(TicketPrice ticketPrice); // Adicionar um preço
        Task UpdateAsync(TicketPrice ticketPrice); // Atualizar um preço
    }
}
