using Data;
using Domain.User.Entities;
using Domain.User.Ports;

namespace Domain.User
{
    public class UserRepository : IUserRepository
    {
        private readonly CinemaDbContext _context;

        public UserRepository(CinemaDbContext context)
        {
            _context = context;
        }

        // Implementação de CreateUserAsync
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Implementação de GetUserByIdAsync
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
