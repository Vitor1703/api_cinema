using Data.Guests;
using Data.Rooms;
using Domain.Bookings;
using Domain.Bookings.Entities;
using Domain.Guests.Entities;
using Domain.Rooms.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
