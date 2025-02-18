using AztroWebApplication.Models;
using AztroWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

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
            return await dbContext.User.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await dbContext.User.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            var newUser = dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task<User?> UpdateUserById(int id, User user)
        {
            var userToUpdate = await this.GetUserById(id);
            if (userToUpdate == null) return null;

            user.Id = userToUpdate.Id;
            var userUpdated = UpdateObject(userToUpdate, user);

            dbContext.User.Update(userUpdated);
            await dbContext.SaveChangesAsync();
            return userToUpdate;
        }

        private static T UpdateObject<T>(T current, T newObject)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var newValue = prop.GetValue(newObject);

                // Si es un string y está vacío, se ignora
                if (newValue == null || string.IsNullOrEmpty(newValue.ToString()))
                    continue;

                // Si es un int y su valor es 0 en newObject, se ignora
                if (newValue is int intValue && intValue == 0)
                    continue;
                prop.SetValue(current, newValue);
            }
            return current;
        }

        public async Task<User?> DeleteUserById(int id)
        {
            var userToDelete = await this.GetUserById(id);
            if (userToDelete == null) return null;

            dbContext.User.Remove(userToDelete);
            await dbContext.SaveChangesAsync();
            return userToDelete;
        }
    }
}