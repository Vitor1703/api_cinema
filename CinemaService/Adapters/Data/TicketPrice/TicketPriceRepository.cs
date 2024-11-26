using Data;
using Domain.TicketPrices.Entities;
using Domain.TicketPrices.Ports;
using Microsoft.EntityFrameworkCore;

public class TicketPriceRepository : ITicketPriceRepository
{
    private readonly CinemaDbContext _context;

    public TicketPriceRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TicketPrice>> GetAllAsync()
    {
        return await _context.TicketPrices.ToListAsync();
    }

    public async Task<TicketPrice> GetByIdAsync(int id)
    {
        return await _context.TicketPrices.FindAsync(id);
    }

    public async Task AddAsync(TicketPrice ticketPrice)
    {
        await _context.TicketPrices.AddAsync(ticketPrice);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketPrice ticketPrice)
    {
        _context.TicketPrices.Update(ticketPrice);
        await _context.SaveChangesAsync();
    }
}
