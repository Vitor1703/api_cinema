using Application.Responses;
using Application.Users.Dtos;
using Application.Users.Requests;

namespace Application.Users.Ports
{
    public interface IUserManager
    {
        Task<UserDto> CreateUserAsync(CreateUserRequest request);

        Task<UserResponse> GetUserByIdAsync(int id);

        Task<UserDto> LoginAsync(LoginRequest request);
    }
}
