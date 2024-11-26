using Data.Users;
using Domain.Movies.Entities;
using Domain.Rooms.Entities;
using Domain.Sessions.Entities;
using Domain.TicketPrices.Entities;
using Domain.Tickets.Entities;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CinemaDbContext : DbContext
    {

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }

        public DbSet<Movie>? Movies { get; set; }

        public DbSet<Room>? Rooms { get; set; }

        public DbSet<Session>? Sessions { get; set; }

        public DbSet<Ticket>? Tickets { get; set; }

        public DbSet<TicketPrice>? TicketPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
