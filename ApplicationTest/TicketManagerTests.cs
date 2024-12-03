using Moq;
using Application.Tickets;
using Domain.Tickets.Entities;
using Domain.Tickets.Ports;
using Application.Tickets.Dtos;
using Application.Tickets.Requests;
using NUnit.Framework;

namespace ApplicationTest
{
    [TestFixture]
    public class TicketManagerTests
    {
        private TicketManager _ticketManager;
        private Ticket _fakeTicket;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<ITicketRepository>();

            _fakeTicket = new Ticket
            {
                Id = 1,
                SessionId = 1,
                UserId = 1,
                SeatNumber = 1,
                PurchaseDate = DateTime.UtcNow,
                Price = 50.00m
            };

            fakeRepo.Setup(x => x.GetBySessionIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Ticket> { _fakeTicket });
            fakeRepo.Setup(x => x.GetByUserIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Ticket> { _fakeTicket });
            fakeRepo.Setup(x => x.AddAsync(It.IsAny<Ticket>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.CancelAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            _ticketManager = new TicketManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Get_Tickets_By_Session_Id()
        {
            var sessionId = 1;
            var response = await _ticketManager.GetBySessionIdAsync(sessionId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().SeatNumber, Is.EqualTo(_fakeTicket.SeatNumber));
            Console.WriteLine("Tickets by session ID retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Tickets_By_User_Id()
        {
            var userId = 1;
            var response = await _ticketManager.GetByUserIdAsync(userId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().UserId, Is.EqualTo(userId));
            Console.WriteLine("Tickets by user ID retrieved successfully!");
        }

        [Test]
        public async Task Should_Add_New_Ticket()
        {
            var request = new CreateTicketRequest
            {
                SessionId = 1,
                UserId = 1,
                SeatNumber = 2,
                Price = 45.00m
            };

            Assert.DoesNotThrowAsync(async () => await _ticketManager.AddAsync(request));
            Console.WriteLine("Ticket added successfully!");
        }

        [Test]
        public async Task Should_Throw_Error_If_Seat_Already_Reserved()
        {
            var request = new CreateTicketRequest
            {
                SessionId = 1,
                UserId = 2,
                SeatNumber = 1, // Mesma cadeira que _fakeTicket
                Price = 45.00m
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _ticketManager.AddAsync(request);
            });

            Console.WriteLine("Error thrown for reserved seat.");
        }

        [Test]
        public async Task Should_Cancel_Ticket()
        {
            Assert.DoesNotThrowAsync(async () => await _ticketManager.CancelAsync(_fakeTicket.Id));
            Console.WriteLine("Ticket canceled successfully!");
        }
    }
}
