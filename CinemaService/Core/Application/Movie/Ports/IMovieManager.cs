using Application.Movies.Dtos;
using Application.Movies.Requests;

namespace Application.Movies.Ports
{
    public interface IMovieManager
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<IEnumerable<MovieDto>> GetShowingMoviesAsync();
        Task<MovieDto> GetByIdAsync(int id);
        Task AddAsync(CreateMovieRequest request);
        Task UpdateAsync(int id, UpdateMovieRequest request);
        Task DeactivateAsync(int id);
    }
}
