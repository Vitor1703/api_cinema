using Application.TicketPrices.Dtos;
using Application.TicketPrices.Requests;

namespace Application.TicketPrices.Ports
{
    public interface ITicketPriceManager
    {
        Task<IEnumerable<TicketPriceDto>> GetAllAsync(); // Listar todos os preços
        Task<TicketPriceDto> GetByIdAsync(int id); // Obter preço pelo ID
        Task AddAsync(CreateTicketPriceRequest request); // Adicionar um novo preço
        Task UpdateAsync(int id, UpdateTicketPriceRequest request); // Atualizar um preço
        Task DeactivateAsync(int id); // Desativar um preço
    }
}
