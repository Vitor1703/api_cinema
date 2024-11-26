using Application.Tickets.Dtos;
using Application.Tickets.Ports;
using Application.Tickets.Requests;
using Domain.Tickets.Entities;
using Domain.Tickets.Ports;

namespace Application.Tickets
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<TicketDto>> GetBySessionIdAsync(int sessionId)
        {
            var tickets = await _ticketRepository.GetBySessionIdAsync(sessionId);
            return tickets.Select(t => new TicketDto(t));
        }

        public async Task<IEnumerable<TicketDto>> GetByUserIdAsync(int userId)
        {
            var tickets = await _ticketRepository.GetByUserIdAsync(userId);
            return tickets.Select(t => new TicketDto(t));
        }

        public async Task AddAsync(CreateTicketRequest request)
        {
            // Validações (exemplo: assento duplicado)
            var existingTickets = await _ticketRepository.GetBySessionIdAsync(request.SessionId);
            if (existingTickets.Any(t => t.SeatNumber == request.SeatNumber))
            {
                throw new InvalidOperationException("Seat already reserved for this session.");
            }

            var ticket = new Ticket
            {
                SessionId = request.SessionId,
                UserId = request.UserId,
                SeatNumber = request.SeatNumber,
                PurchaseDate = DateTime.UtcNow,
                Price = request.Price
            };

            await _ticketRepository.AddAsync(ticket);
        }

        public async Task CancelAsync(int id)
        {
            await _ticketRepository.CancelAsync(id);
        }
    }
}
