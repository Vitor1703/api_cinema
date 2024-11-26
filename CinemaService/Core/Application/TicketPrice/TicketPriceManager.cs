using Application.TicketPrices.Dtos;
using Application.TicketPrices.Ports;
using Application.TicketPrices.Requests;
using Domain.TicketPrices.Entities;
using Domain.TicketPrices.Ports;

namespace Application.TicketPrices
{
    public class TicketPriceManager : ITicketPriceManager
    {
        private readonly ITicketPriceRepository _repository;

        public TicketPriceManager(ITicketPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TicketPriceDto>> GetAllAsync()
        {
            var prices = await _repository.GetAllAsync();
            return prices.Select(p => new TicketPriceDto(p));
        }

        public async Task<TicketPriceDto> GetByIdAsync(int id)
        {
            var price = await _repository.GetByIdAsync(id);
            return price != null ? new TicketPriceDto(price) : null;
        }

        public async Task AddAsync(CreateTicketPriceRequest request)
        {
            var ticketPrice = new TicketPrice
            {
                Price = request.Price
            };

            await _repository.AddAsync(ticketPrice);
        }

        public async Task UpdateAsync(int id, UpdateTicketPriceRequest request)
        {
            var ticketPrice = await _repository.GetByIdAsync(id);
            if (ticketPrice == null)
            {
                throw new KeyNotFoundException("Ticket price not found");
            }

            ticketPrice.Price = request.Price;
            ticketPrice.IsActive = request.IsActive;
            ticketPrice.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(ticketPrice);
        }

        public async Task DeactivateAsync(int id)
        {
            var ticketPrice = await _repository.GetByIdAsync(id);
            if (ticketPrice == null)
            {
                throw new KeyNotFoundException("Ticket price not found");
            }

            ticketPrice.IsActive = false;
            await _repository.UpdateAsync(ticketPrice);
        }
    }
}
