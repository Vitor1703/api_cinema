using Application.Users.Ports;
using Application.Users.Requests;
using Application.Responses;
using Domain.Users.Entities;
using Domain.Users.Ports;
using Application.Users.Dtos;

namespace Application.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
        {
            // Verificar se usuário já existe
            var exists = await _userRepository.GetByEmailOrUsernameAsync(request.Email, request.Username);
            if (exists != null)
            {
                throw new InvalidOperationException("Username or email already exists.");
            }

            // Criar novo usuário
            var user = new User
            {
                Username = request.Username,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password, // Certifique-se de que está armazenando de forma segura
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateUserAsync(user);

            // Retornar o DTO diretamente
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return new UserResponse(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            });
        }

        public async Task<UserDto> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByUsernameAndPasswordAsync(request.Username, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
