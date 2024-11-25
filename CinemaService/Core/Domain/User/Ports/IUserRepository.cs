using Domain.Users.Entities;

namespace Domain.Users.Ports
{
    public interface IUserRepository
    {
        // Cria um novo usuário e retorna o usuário criado
        Task<User> CreateUserAsync(User user);

        // Obtém um usuário pelo ID
        Task<User> GetUserByIdAsync(int id);
    }
}
