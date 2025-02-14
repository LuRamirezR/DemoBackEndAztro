using AztroWebApplication.Models;
using AztroWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AztroWebApplication.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id)!;
        }

        public async Task<User> CreateUser(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserById(int id, User user)
        {
            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Age = user.Age;

            await dbContext.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<User?> DeleteUserById(int id)
        {
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return null;
            }

            dbContext.Users.Remove(userToDelete);
            await dbContext.SaveChangesAsync();
            return userToDelete;
        }
    }
}