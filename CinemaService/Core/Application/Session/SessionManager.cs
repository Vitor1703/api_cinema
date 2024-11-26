using Application.Sessions.Dtos;
using Application.Sessions.Ports;
using Application.Sessions.Requests;
using Domain.Sessions.Entities;
using Domain.Sessions.Ports;

namespace Application.Sessions
{
    public class SessionManager : ISessionManager
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionManager(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<SessionDto>> GetAllAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            return sessions.Select(s => new SessionDto(s));
        }

        public async Task<IEnumerable<SessionDto>> GetByMovieIdAsync(int movieId)
        {
            var sessions = await _sessionRepository.GetByMovieIdAsync(movieId);
            return sessions.Select(s => new SessionDto(s));
        }

        public async Task<IEnumerable<SessionDto>> GetByRoomIdAsync(int roomId)
        {
            var sessions = await _sessionRepository.GetByRoomIdAsync(roomId);
            return sessions.Select(s => new SessionDto(s));
        }

        public async Task AddAsync(CreateSessionRequest request)
        {
            var session = new Session
            {
                MovieId = request.MovieId,
                RoomId = request.RoomId,
                StartTime = request.StartTime,
                EndTime = request.StartTime.AddMinutes(request.Duration),
                Price = request.Price,
                IsActive = true
            };

            await _sessionRepository.AddAsync(session);
        }

        public async Task UpdateAsync(int id, UpdateSessionRequest request)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null)
            {
                throw new KeyNotFoundException("Session not found");
            }

            session.StartTime = request.StartTime;
            session.EndTime = request.StartTime.AddMinutes(request.Duration);
            session.Price = request.Price;

            await _sessionRepository.UpdateAsync(session);
        }

        public async Task DeactivateAsync(int id)
        {
            await _sessionRepository.DeactivateAsync(id);
        }
    }
}
