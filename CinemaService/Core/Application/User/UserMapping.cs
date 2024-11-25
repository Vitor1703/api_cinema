using Core.Application.User.Dtos;
using Domain.Entities;

namespace Core.Application.User
{
    public static class UserMapping
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
