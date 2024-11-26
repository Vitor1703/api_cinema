using Data;
using Domain.Sessions.Entities;
using Domain.Sessions.Ports;
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository
{
    private readonly CinemaDbContext _context;

    public SessionRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Session>> GetAllAsync()
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Room)
            .ToListAsync();
    }

    public async Task<IEnumerable<Session>> GetByMovieIdAsync(int movieId)
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Room)
            .Where(s => s.MovieId == movieId && s.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Session>> GetByRoomIdAsync(int roomId)
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Room)
            .Where(s => s.RoomId == roomId && s.IsActive)
            .ToListAsync();
    }

    public async Task<Session> GetByIdAsync(int id)
    {
        return await _context.Sessions
            .Include(s => s.Movie)
            .Include(s => s.Room)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Session session)
    {
        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Session session)
    {
        _context.Sessions.Update(session);
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateAsync(int id)
    {
        var session = await _context.Sessions.FindAsync(id);
        if (session != null)
        {
            session.IsActive = false;
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }
    }
}
