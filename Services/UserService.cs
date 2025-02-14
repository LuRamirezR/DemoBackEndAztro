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

        public User CreateUser()
        {
            return new User();
        }

        public User UpdateUserById(int id)
        {
            return new User();
        }

        public User DeleteUserById(int id)
        {
            return new User();
        }
    }
}