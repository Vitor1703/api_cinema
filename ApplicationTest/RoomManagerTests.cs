using Moq;
using Application.Rooms;
using Domain.Rooms.Entities;
using Domain.Rooms.Ports;
using Application.Rooms.Dtos;
using Application.Rooms.Requests;
using NUnit.Framework;

namespace ApplicationTest
{
    [TestFixture]
    public class RoomManagerTests
    {
        private RoomManager _roomManager;
        private Room _fakeRoom;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<IRoomRepository>();

            _fakeRoom = new Room
            {
                Id = 1,
                Name = "Test Room",
                Capacity = 100,
                IsActive = true
            };

            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_fakeRoom);
            fakeRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Room> { _fakeRoom });
            fakeRepo.Setup(x => x.AddAsync(It.IsAny<Room>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.UpdateAsync(It.IsAny<Room>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.DeactivateAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            _roomManager = new RoomManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Get_All_Rooms()
        {
            var response = await _roomManager.GetAllAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Name, Is.EqualTo(_fakeRoom.Name));
            Console.WriteLine("Rooms retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Room_By_Id()
        {
            var roomId = 1;
            var response = await _roomManager.GetByIdAsync(roomId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Id, Is.EqualTo(_fakeRoom.Id));
            Assert.That(response.Name, Is.EqualTo(_fakeRoom.Name));
            Console.WriteLine("Room retrieved successfully!");
        }

        [Test]
        public async Task Should_Add_New_Room()
        {
            var request = new CreateRoomRequest
            {
                Name = "New Room",
                Capacity = 50
            };

            Assert.DoesNotThrowAsync(async () => await _roomManager.AddAsync(request));
            Console.WriteLine("Room added successfully!");
        }

        [Test]
        public async Task Should_Update_Room()
        {
            var updateRequest = new UpdateRoomRequest
            {
                Name = "Updated Room",
                Capacity = 150
            };

            Assert.DoesNotThrowAsync(async () => await _roomManager.UpdateAsync(_fakeRoom.Id, updateRequest));
            Console.WriteLine("Room updated successfully!");
        }

        [Test]
        public async Task Should_Throw_Error_When_Updating_Non_Existing_Room()
        {
            var fakeRepo = new Mock<IRoomRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Room?)null);

            var roomManagerWithNoRoom = new RoomManager(fakeRepo.Object);

            var updateRequest = new UpdateRoomRequest
            {
                Name = "Updated Room",
                Capacity = 150
            };

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await roomManagerWithNoRoom.UpdateAsync(99, updateRequest);
            });

            Console.WriteLine("Error thrown for updating non-existing room.");
        }

        [Test]
        public async Task Should_Deactivate_Room()
        {
            Assert.DoesNotThrowAsync(async () => await _roomManager.DeactivateAsync(_fakeRoom.Id));
            Console.WriteLine("Room deactivated successfully!");
        }
    }
}
