namespace Application.Users.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
