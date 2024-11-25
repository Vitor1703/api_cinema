using Domain.Entities;

namespace Application.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterUserAsync(User user)
        {
            if (await _repository.UserExistsAsync(user.Username, user.Email))
            {
                throw new Exception("Username or email already exists.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _repository.AddUserAsync(user);
        }
    }
}
