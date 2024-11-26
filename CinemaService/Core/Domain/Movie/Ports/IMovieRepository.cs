using Domain.Movies.Entities;

namespace Domain.Movies.Ports
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync(); // Listar todos os filmes
        Task<IEnumerable<Movie>> GetShowingMoviesAsync(); // Listar filmes em cartaz
        Task<Movie> GetByIdAsync(int id); // Obter filme pelo ID
        Task AddAsync(Movie movie); // Cadastrar um filme
        Task UpdateAsync(Movie movie); // Alterar um filme
        Task DeactivateAsync(int id); // Desativar um filme
    }
}
