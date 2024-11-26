using Data.Users;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CinemaDbContext : DbContext
    {

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
