using Application.Responses;
using Application.Tickets.Dtos;
using Application.Tickets.Requests;

namespace Application.Tickets.Ports
{
    public interface ITicketManager
    {
        Task<IEnumerable<TicketDto>> GetBySessionIdAsync(int sessionId);
        Task<IEnumerable<TicketDto>> GetByUserIdAsync(int userId);
        Task AddAsync(CreateTicketRequest request);
        Task CancelAsync(int id);
    }
}
