using Moq;
using Application.Sessions;
using Domain.Sessions.Entities;
using Domain.Sessions.Ports;
using Application.Sessions.Requests;

namespace ApplicationTest
{
    [TestFixture]
    public class SessionManagerTests
    {
        private SessionManager _sessionManager;
        private Session _fakeSession;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<ISessionRepository>();

            _fakeSession = new Session
            {
                Id = 1,
                MovieId = 1,
                RoomId = 1,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(2),
                Price = 15.50m,
                IsActive = true
            };

            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_fakeSession);
            fakeRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Session> { _fakeSession });
            fakeRepo.Setup(x => x.GetByMovieIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Session> { _fakeSession });
            fakeRepo.Setup(x => x.GetByRoomIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Session> { _fakeSession });
            fakeRepo.Setup(x => x.AddAsync(It.IsAny<Session>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.UpdateAsync(It.IsAny<Session>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.DeactivateAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            _sessionManager = new SessionManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Get_All_Sessions()
        {
            var response = await _sessionManager.GetAllAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().MovieId, Is.EqualTo(_fakeSession.MovieId));
            Console.WriteLine("Sessions retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Sessions_By_Movie_Id()
        {
            var movieId = 1;
            var response = await _sessionManager.GetByMovieIdAsync(movieId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.First().MovieId, Is.EqualTo(movieId));
            Console.WriteLine("Sessions by movie ID retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Sessions_By_Room_Id()
        {
            var roomId = 1;
            var response = await _sessionManager.GetByRoomIdAsync(roomId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.First().RoomId, Is.EqualTo(roomId));
            Console.WriteLine("Sessions by room ID retrieved successfully!");
        }

        [Test]
        public async Task Should_Add_New_Session()
        {
            var request = new CreateSessionRequest
            {
                MovieId = 1,
                RoomId = 1,
                StartTime = DateTime.UtcNow,
                Duration = 120,
                Price = 20.00m
            };

            Assert.DoesNotThrowAsync(async () => await _sessionManager.AddAsync(request));
            Console.WriteLine("Session added successfully!");
        }

        [Test]
        public async Task Should_Update_Session()
        {
            var updateRequest = new UpdateSessionRequest
            {
                StartTime = DateTime.UtcNow,
                Duration = 120,
                Price = 25.00m
            };

            Assert.DoesNotThrowAsync(async () => await _sessionManager.UpdateAsync(_fakeSession.Id, updateRequest));
            Console.WriteLine("Session updated successfully!");
        }

        [Test]
        public async Task Should_Throw_Error_When_Updating_Non_Existing_Session()
        {
            var fakeRepo = new Mock<ISessionRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Session?)null);

            var sessionManagerWithNoSession = new SessionManager(fakeRepo.Object);

            var updateRequest = new UpdateSessionRequest
            {
                StartTime = DateTime.UtcNow,
                Duration = 120,
                Price = 25.00m
            };

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await sessionManagerWithNoSession.UpdateAsync(99, updateRequest);
            });

            Console.WriteLine("Error thrown for updating non-existing session.");
        }

        [Test]
        public async Task Should_Deactivate_Session()
        {
            Assert.DoesNotThrowAsync(async () => await _sessionManager.DeactivateAsync(_fakeSession.Id));
            Console.WriteLine("Session deactivated successfully!");
        }
    }
}
