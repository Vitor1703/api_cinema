using Domain.Sessions.Entities;

namespace Domain.Sessions.Ports
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllAsync(); // Listar todas as sessões
        Task<IEnumerable<Session>> GetByMovieIdAsync(int movieId); // Listar sessões por filme
        Task<IEnumerable<Session>> GetByRoomIdAsync(int roomId); // Listar sessões por sala
        Task<Session> GetByIdAsync(int id); // Obter sessão pelo ID
        Task AddAsync(Session session); // Cadastrar uma nova sessão
        Task UpdateAsync(Session session); // Alterar informações de uma sessão
        Task DeactivateAsync(int id); // Desativar uma sessão
    }
}
