using Application.Responses;
using Application.Sessions.Dtos;
using Application.Sessions.Requests;

namespace Application.Sessions.Ports
{
    public interface ISessionManager
    {
        Task<IEnumerable<SessionDto>> GetAllAsync();
        Task<IEnumerable<SessionDto>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<SessionDto>> GetByRoomIdAsync(int roomId);
        Task AddAsync(CreateSessionRequest request);
        Task UpdateAsync(int id, UpdateSessionRequest request);
        Task DeactivateAsync(int id);
    }
}
