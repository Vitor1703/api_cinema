using Domain.Rooms.Entities;

namespace Domain.Rooms.Ports
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync(); // Listar todas as salas
        Task<Room> GetByIdAsync(int id); // Obter detalhes de uma sala
        Task AddAsync(Room room); // Cadastrar uma sala
        Task UpdateAsync(Room room); // Alterar informações de uma sala
        Task DeactivateAsync(int id); // Desativar uma sala
    }
}
