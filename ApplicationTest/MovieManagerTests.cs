using Moq;
using Application.Movies;
using Domain.Movies.Entities;
using Domain.Movies.Ports;
using Application.Movies.Requests;

namespace ApplicationTest
{
    [TestFixture]
    public class MovieManagerTests
    {
        private MovieManager _movieManager;
        private Movie _fakeMovie;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<IMovieRepository>();

            _fakeMovie = new Movie
            {
                Id = 1,
                Title = "Test Movie",
                Description = "Test Description",
                Duration = 120,
                AverageRating = 4.5,
                IsShowing = true,
                IsActive = true,
                ImageUrl = "https://example.com/movie.jpg"
            };

            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_fakeMovie);
            fakeRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Movie> { _fakeMovie });
            fakeRepo.Setup(x => x.GetShowingMoviesAsync()).ReturnsAsync(new List<Movie> { _fakeMovie });
            fakeRepo.Setup(x => x.AddAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.UpdateAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.DeactivateAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            _movieManager = new MovieManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Get_All_Movies()
        {
            var response = await _movieManager.GetAllAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Title, Is.EqualTo(_fakeMovie.Title));
            Console.WriteLine("Movies retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Showing_Movies()
        {
            var response = await _movieManager.GetShowingMoviesAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().IsShowing, Is.True);
            Console.WriteLine("Showing movies retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Movie_By_Id()
        {
            var movieId = 1;
            var response = await _movieManager.GetByIdAsync(movieId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Id, Is.EqualTo(_fakeMovie.Id));
            Assert.That(response.Title, Is.EqualTo(_fakeMovie.Title));
            Console.WriteLine("Movie retrieved successfully!");
        }

        [Test]
        public async Task Should_Add_New_Movie()
        {
            var request = new CreateMovieRequest
            {
                Title = "New Movie",
                Description = "New Description",
                Duration = 90,
                IsShowing = true,
                ImageUrl = "https://example.com/newmovie.jpg"
            };

            Assert.DoesNotThrowAsync(async () => await _movieManager.AddAsync(request));
            Console.WriteLine("Movie added successfully!");
        }

        [Test]
        public async Task Should_Update_Movie()
        {
            var updateRequest = new UpdateMovieRequest
            {
                Title = "Updated Movie",
                Description = "Updated Description",
                Duration = 100,
                IsShowing = false,
                ImageUrl = "https://example.com/updatedmovie.jpg"
            };

            Assert.DoesNotThrowAsync(async () => await _movieManager.UpdateAsync(_fakeMovie.Id, updateRequest));
            Console.WriteLine("Movie updated successfully!");
        }

        [Test]
        public async Task Should_Throw_Error_When_Updating_Non_Existing_Movie()
        {
            var fakeRepo = new Mock<IMovieRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Movie?)null);

            var movieManagerWithNoMovie = new MovieManager(fakeRepo.Object);

            var updateRequest = new UpdateMovieRequest
            {
                Title = "Updated Movie",
                Description = "Updated Description",
                Duration = 100,
                IsShowing = false,
                ImageUrl = "https://example.com/updatedmovie.jpg"
            };

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await movieManagerWithNoMovie.UpdateAsync(99, updateRequest);
            });

            Console.WriteLine("Error thrown for updating non-existing movie.");
        }

        [Test]
        public async Task Should_Deactivate_Movie()
        {
            Assert.DoesNotThrowAsync(async () => await _movieManager.DeactivateAsync(_fakeMovie.Id));
            Console.WriteLine("Movie deactivated successfully!");
        }
    }
}
