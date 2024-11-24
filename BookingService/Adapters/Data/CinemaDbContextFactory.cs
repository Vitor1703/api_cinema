using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class CinemaDbContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
{
    public CinemaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();

        // Defina a conexão com o PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Bi@nc@");

        return new CinemaDbContext(optionsBuilder.Options);
    }
}
