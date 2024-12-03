using Moq;
using Application.Users;
using Domain.Users.Entities;
using Domain.Users.Ports;
using AutoMapper;
using Application.Users.Dtos;
using Application.Users.Requests;

namespace ApplicationTest
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager _userManager;
        private User _fakeUser;

        [SetUp]
        public void Setup()
        {
            var fakeRepo = new Mock<IUserRepository>();

            _fakeUser = new User
            {
                Id = 1,
                Username = "testuser",
                Email = "testuser@example.com",
                Password = "password123",
                CreatedAt = DateTime.UtcNow
            };

            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_fakeUser);
            fakeRepo.Setup(x => x.GetByEmailOrUsernameAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((User?)null);
            fakeRepo.Setup(x => x.CreateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            _userManager = new UserManager(fakeRepo.Object);
        }

        [Test]
        public async Task Should_Create_User_Successfully()
        {
            var request = new CreateUserRequest
            {
                Username = "testuser",
                Email = "testuser@example.com",
                Password = "password123"
            };

            var response = await _userManager.CreateUserAsync(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Username, Is.EqualTo(request.Username));
            Assert.That(response.Email, Is.EqualTo(request.Email));
            Console.WriteLine("User created successfully!");
        }

        [Test]
        public async Task Should_Not_Create_User_If_Username_Or_Email_Exists()
        {
            var request = new CreateUserRequest
            {
                Username = "testuser",
                Email = "testuser@example.com",
                Password = "password123"
            };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetByEmailOrUsernameAsync(request.Email, request.Username))
                .ReturnsAsync(_fakeUser);

            var userManagerWithConflict = new UserManager(fakeRepo.Object);

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await userManagerWithConflict.CreateUserAsync(request);
            });

            Console.WriteLine("Conflict detected for username or email.");
        }

        [Test]
        public async Task Should_Login_User_Successfully()
        {
            var loginRequest = new LoginRequest
            {
                Username = "testuser",
                Password = "password123"
            };

            // Configura o mock para simular o comportamento correto
            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetByUsernameAndPasswordAsync(loginRequest.Username, loginRequest.Password))
                .ReturnsAsync(_fakeUser); // Retorna o usuário esperado

            var userManagerWithLogin = new UserManager(fakeRepo.Object);
            var response = await userManagerWithLogin.LoginAsync(loginRequest);

            // Verifica se o login foi bem-sucedido
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Username, Is.EqualTo(_fakeUser.Username));
            Assert.That(response.Email, Is.EqualTo(_fakeUser.Email));
            Console.WriteLine("Login successful!");
        }


        [Test]
        public async Task Should_Return_Error_If_User_Not_Found_On_Login()
        {
            var loginRequest = new LoginRequest
            {
                Username = "nonexistentuser",
                Password = "password123"
            };

            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetByEmailOrUsernameAsync(It.IsAny<string>(), loginRequest.Username))
                .ReturnsAsync((User?)null);

            var userManagerWithNoUser = new UserManager(fakeRepo.Object);
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await userManagerWithNoUser.LoginAsync(loginRequest);
            });

            Console.WriteLine("Unauthorized access exception for invalid login.");
        }

        [Test]
        public async Task Should_Get_User_By_Id_Successfully()
        {
            var userId = 1;
            var response = await _userManager.GetUserByIdAsync(userId);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data.Id, Is.EqualTo(_fakeUser.Id));
            Assert.That(response.Data.Username, Is.EqualTo(_fakeUser.Username));
            Console.WriteLine("User retrieved successfully!");
        }

        [Test]
        public async Task Should_Return_Error_If_User_Not_Found_By_Id()
        {
            var fakeRepo = new Mock<IUserRepository>();
            fakeRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((User?)null);

            var userManagerWithNoUser = new UserManager(fakeRepo.Object);

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await userManagerWithNoUser.GetUserByIdAsync(99);
            });

            Console.WriteLine("No user found for given ID.");
        }
    }
}
