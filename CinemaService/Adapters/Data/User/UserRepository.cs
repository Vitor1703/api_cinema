using Data;
using Domain.Users.Entities;
using Domain.Users.Ports;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly CinemaDbContext _context;

    public UserRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetByEmailOrUsernameAsync(string email, string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email || u.Username == username);
    }

    public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}
