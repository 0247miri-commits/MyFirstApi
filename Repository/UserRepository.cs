using Entities;
using System.Text.Json;


using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly storeDBContext _context;
        public UserRepository(storeDBContext context)
        {
            _context = context;
        }
      

        public async Task<User?> GetUserFromDb(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UniqueEmail(string email)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email);
        }
      
        async public Task InsertUserToDb(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<int>   UserExistsInDb(LoginDetails loginDetails)
        {
            return await _context.Users
                  .Where(u => u.Email == loginDetails.Email && u.Password == loginDetails.Password)
                  .Select(u => u.Id)
                  .FirstOrDefaultAsync();
        }



        public async Task UpdateUserInDb(int id, User userToUpdate)
        {


       
            User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                return;
            }

            existingUser.First_name = userToUpdate.First_name;
            existingUser.Last_name = userToUpdate.Last_name;
            existingUser.Email = userToUpdate.Email;
            existingUser.Password = userToUpdate.Password;

            await _context.SaveChangesAsync();
        }

    
    }
}

