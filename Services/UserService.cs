using AztroWebApplication.Data;
using AztroWebApplication.Models;
using AztroWebApplication.Repositories;

namespace AztroWebApplication.Services
{
    public class UserService
    {

        private readonly UserRepository userRepository;

        public UserService(ApplicationDbContext context)
        {
            userRepository = new UserRepository(context);
        }

        public async Task<List<User>> GetAllUsers()
        {
            // llama al repositorio para traer la informacion de la base de datos
            return await userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<User> CreateUser(User user)
        {
            return await userRepository.CreateUser(user);
        }

        public async Task<User?> UpdateUserById(int id, User user)
        {
            return await userRepository.UpdateUserById(id, user);
        }

        public async Task<User?> DeleteUserById(int id)
        {
            return await userRepository.DeleteUserById(id);
        }
    }
}