using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User?> GetUser(int id);
        Task InsertUser(User user);
        PasswordStrengthResult PasswordStrong(string password);
        Task<bool> UniqueUser(User user);
        Task UpdateUserInSystem(int id, User userToUpdate);
        Task<int> UserExistsInSystem(LoginDetails user);
        bool VaildPassword(User  user);
    }
}