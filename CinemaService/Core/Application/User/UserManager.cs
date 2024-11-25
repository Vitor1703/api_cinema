// using Application.Common;
// using Application.User.Dtos;
// using Application.User.Ports;
// using Application.User.Requests;
// using Domain.User.Entities;
// using Domain.User.Ports;

// namespace Core.Application.User
// {
//     public class UserManager : IUserManager
//     {
//         private readonly UserRepository _userRepository;

//         public UserManager(UserRepository userRepository)
//         {
//             _userRepository = userRepository;
//         }

//         public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
//         {
//             // Verificar se usuário já existe
//             var exists = await _userRepository.UserExistsAsync(request.Username, request.Email);
//             if (exists)
//             {
//                 return new UserResponse
//                 {
//                     Message = "Username or email already exists."
//                 };
//             }

//             // Criar novo usuário
//             var user = new Domain.Entities.User
//             {
//                 Username = request.Username,
//                 Name = request.Name,
//                 Email = request.Email,
//                 Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
//             };

//             await _userRepository.AddUserAsync(user);

//             return new UserResponse
//             {
//                 Id = user.Id,
//                 Username = user.Username,
//                 Name = user.Name,
//                 Email = user.Email,
//                 Message = "User created successfully."
//             };
//         }

//         public async Task<UserResponse> GetUserByIdAsync(int id)
//         {
//             var user = await _userRepository.GetUserByIdAsync(id);
//             if (user == null)
//             {
//                 return null;
//             }

//             return new UserResponse
//             {
//                 Id = user.Id,
//                 Username = user.Username,
//                 Name = user.Name,
//                 Email = user.Email,
//                 Message = "User retrieved successfully."
//             };
//         }
//     }
// }
