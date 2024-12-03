using Application.Movies.Dtos;
using Application.Movies.Ports;
using Application.Movies.Requests;
using Domain.Movies.Entities;
using Domain.Movies.Ports;

namespace Application.Movies
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return movies.Select(m => new MovieDto(m));
        }

        public async Task<IEnumerable<MovieDto>> GetShowingMoviesAsync()
        {
            var movies = await _movieRepository.GetShowingMoviesAsync();
            return movies.Select(m => new MovieDto(m));
        }

        public async Task<MovieDto> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie != null ? new MovieDto(movie) : null;
        }

        public async Task AddAsync(CreateMovieRequest request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                Duration = request.Duration,
                AverageRating = 0,
                IsShowing = request.IsShowing,
                IsActive = true,
                ImageUrl = request.ImageUrl
            };

            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(int id, UpdateMovieRequest request)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                throw new KeyNotFoundException("Movie not found");
            }

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Duration = request.Duration;
            movie.IsShowing = request.IsShowing;
            movie.ImageUrl = request.ImageUrl;

            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeactivateAsync(int id)
        {
            await _movieRepository.DeactivateAsync(id);
        }
    }
}
