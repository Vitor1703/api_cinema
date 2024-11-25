using Core.Application.User.Requests;
using Core.Application.User.Responses;

namespace Core.Application.User.Ports
{
    public interface IUserManager
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest request);
        Task<UserResponse> GetUserByIdAsync(int id);
    }
}
