using Core.Application.User.Requests;

namespace Core.Application.User.Ports
{
    public interface IUserManager
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest request);
        Task<UserResponse> GetUserByIdAsync(int id);
    }
}
