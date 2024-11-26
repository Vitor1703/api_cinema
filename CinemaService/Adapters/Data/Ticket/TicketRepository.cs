using Data;
using Domain.Tickets.Entities;
using Domain.Tickets.Ports;
using Microsoft.EntityFrameworkCore;

public class TicketRepository : ITicketRepository
{
    private readonly CinemaDbContext _context;

    public TicketRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetBySessionIdAsync(int sessionId)
    {
        return await _context.Tickets
            .Include(t => t.Session)
            .Include(t => t.User)
            .Where(t => t.SessionId == sessionId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Ticket>> GetByUserIdAsync(int userId)
    {
        return await _context.Tickets
            .Include(t => t.Session)
            .Include(t => t.User)
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task<Ticket> GetByIdAsync(int id)
    {
        return await _context.Tickets
            .Include(t => t.Session)
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task CancelAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
