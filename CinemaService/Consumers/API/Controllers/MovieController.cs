using Application.Movies.Dtos;
using Application.Movies.Ports;
using Application.Movies.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieManager _movieManager;

        public MovieController(IMovieManager movieManager)
        {
            _movieManager = movieManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _movieManager.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("showing")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetShowingMovies()
        {
            var movies = await _movieManager.GetShowingMoviesAsync();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieRequest request)
        {
            await _movieManager.AddAsync(request);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovieRequest request)
        {
            await _movieManager.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _movieManager.DeactivateAsync(id);
            return NoContent();
        }
    }
}
