using Data;
using Domain.Movies.Entities;
using Domain.Movies.Ports;
using Microsoft.EntityFrameworkCore;

public class MovieRepository : IMovieRepository
{
    private readonly CinemaDbContext _context;

    public MovieRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetShowingMoviesAsync()
    {
        return await _context.Movies.Where(m => m.IsShowing && m.IsActive).ToListAsync();
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task AddAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            movie.IsActive = false;
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}
