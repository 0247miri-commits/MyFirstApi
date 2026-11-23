using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserFromDb(int id);
        Task InsertUserToDb(User user);
        Task<bool> UniqueEmail(string email);
        Task UpdateUserInDb(int id, User userToUpdate);
        Task<int> UserExistsInDb(LoginDetails loginDetails);

    }
}