using Application.Responses;
using Application.Users.Requests;

namespace Application.Users.Ports
{
    public interface IUserManager
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest request);

        Task<UserResponse> GetUserByIdAsync(int id);

        Task<UserResponse> LoginAsync(LoginRequest request);
    }
}
