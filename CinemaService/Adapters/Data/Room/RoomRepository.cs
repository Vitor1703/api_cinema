using Data;
using Domain.Rooms.Entities;
using Domain.Rooms.Ports;
using Microsoft.EntityFrameworkCore;

public class RoomRepository : IRoomRepository
{
    private readonly CinemaDbContext _context;

    public RoomRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task AddAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room != null)
        {
            room.IsActive = false;
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
