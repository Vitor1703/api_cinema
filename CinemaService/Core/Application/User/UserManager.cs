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

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
        {
            // Verificar se usuário já existe
            var existingUser = await _userRepository.GetByEmailOrUsernameAsync(request.Email, request.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username or email already exists.");
            }

            // Criar novo usuário
            var user = new User
            {
                Username = request.Username,
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateUserAsync(user);

            return new UserResponse(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            });
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
    }
}
