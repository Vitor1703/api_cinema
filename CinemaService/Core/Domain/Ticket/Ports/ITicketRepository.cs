using Domain.Tickets.Entities;

namespace Domain.Tickets.Ports
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetBySessionIdAsync(int sessionId); // Listar ingressos por sessão
        Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId); // Listar ingressos por usuário
        Task<Ticket> GetByIdAsync(int id); // Obter ingresso pelo ID
        Task AddAsync(Ticket ticket); // Comprar um ingresso
        Task CancelAsync(int id); // Cancelar a compra de um ingresso
    }
}
