using Moq;
using Application.TicketPrices;
using Domain.TicketPrices.Entities;
using Domain.TicketPrices.Ports;
using Application.TicketPrices.Dtos;
using Application.TicketPrices.Requests;
using NUnit.Framework;

namespace ApplicationTest
{
    [TestFixture]
    public class TicketPriceManagerTests
    {
        private TicketPriceManager _ticketPriceManager;
        private TicketPrice _fakeTicketPrice;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<ITicketPriceRepository>();

            _fakeTicketPrice = new TicketPrice
            {
                Id = 1,
                Price = 50.00m,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };

            fakeRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<TicketPrice> { _fakeTicketPrice });
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_fakeTicketPrice);
            fakeRepo.Setup(x => x.AddAsync(It.IsAny<TicketPrice>())).Returns(Task.CompletedTask);
            fakeRepo.Setup(x => x.UpdateAsync(It.IsAny<TicketPrice>())).Returns(Task.CompletedTask);

            _ticketPriceManager = new TicketPriceManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Get_All_Ticket_Prices()
        {
            var response = await _ticketPriceManager.GetAllAsync();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Price, Is.EqualTo(_fakeTicketPrice.Price));
            Console.WriteLine("All ticket prices retrieved successfully!");
        }

        [Test]
        public async Task Should_Get_Ticket_Price_By_Id()
        {
            var response = await _ticketPriceManager.GetByIdAsync(_fakeTicketPrice.Id);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Id, Is.EqualTo(_fakeTicketPrice.Id));
            Assert.That(response.Price, Is.EqualTo(_fakeTicketPrice.Price));
            Console.WriteLine("Ticket price retrieved successfully by ID!");
        }

        [Test]
        public async Task Should_Add_New_Ticket_Price()
        {
            var request = new CreateTicketPriceRequest
            {
                Price = 75.00m
            };

            Assert.DoesNotThrowAsync(async () => await _ticketPriceManager.AddAsync(request));
            Console.WriteLine("New ticket price added successfully!");
        }

        [Test]
        public async Task Should_Update_Ticket_Price()
        {
            var request = new UpdateTicketPriceRequest
            {
                Price = 60.00m,
                IsActive = true
            };

            Assert.DoesNotThrowAsync(async () => await _ticketPriceManager.UpdateAsync(_fakeTicketPrice.Id, request));
            Console.WriteLine("Ticket price updated successfully!");
        }

        [Test]
        public async Task Should_Deactivate_Ticket_Price()
        {
            Assert.DoesNotThrowAsync(async () => await _ticketPriceManager.DeactivateAsync(_fakeTicketPrice.Id));
            Console.WriteLine("Ticket price deactivated successfully!");
        }

        [Test]
        public async Task Should_Throw_Error_If_Ticket_Price_Not_Found_On_Update()
        {
            var fakeRepo = new Mock<ITicketPriceRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TicketPrice?)null);

            var managerWithNoData = new TicketPriceManager(fakeRepo.Object);
            var request = new UpdateTicketPriceRequest
            {
                Price = 60.00m,
                IsActive = false
            };

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await managerWithNoData.UpdateAsync(99, request));
            Console.WriteLine("Error thrown for updating non-existent ticket price.");
        }

        [Test]
        public async Task Should_Throw_Error_If_Ticket_Price_Not_Found_On_Deactivate()
        {
            var fakeRepo = new Mock<ITicketPriceRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TicketPrice?)null);

            var managerWithNoData = new TicketPriceManager(fakeRepo.Object);

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await managerWithNoData.DeactivateAsync(99));
            Console.WriteLine("Error thrown for deactivating non-existent ticket price.");
        }
    }
}
