﻿using Domain.Users.Entities;

namespace Domain.Users.Ports
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailOrUsernameAsync(string email, string username);
        Task CreateUserAsync(User user);
    }
}
