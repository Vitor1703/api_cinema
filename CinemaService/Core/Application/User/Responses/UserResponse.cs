using Application.Users.Dtos;

namespace Application.Responses
{
    public class UserResponse : Response
    {
        public UserDto Data { get; set; }

        public UserResponse(UserDto data)
        {
            Data = data;
        }
    }
}
