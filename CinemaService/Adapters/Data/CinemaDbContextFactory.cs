using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class CinemaDbContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
{
    public CinemaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();

        // Defina a conexão com o PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Database=cinema;Username=cinesystem;Password=bianca23");

        return new CinemaDbContext(optionsBuilder.Options);
    }
}
