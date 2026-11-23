using Entities;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Zxcvbn;


namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        // יצירת מופע של UserRepository עם IUserRepository
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User?> GetUser(int id)
        {

            return await _repository.GetUserFromDb(id);

        }
        public bool VaildPassword(User user)
        {
            var result = Core.EvaluatePassword(user.Password);

            if (result.Score < 3)
                return false;
            return true;
        }
        public async Task<bool> UniqueUser(User user)
        {

            if (!await _repository.UniqueEmail(user.Email))
                return    false;
            return true;

        }
        public async Task InsertUser(User user)
        {
            await   _repository.InsertUserToDb(user);
        }
        public PasswordStrengthResult PasswordStrong(string password)
        {
            var result = Core.EvaluatePassword(password);
            if (result.Score < 3)
                return new PasswordStrengthResult
                {
                    Score = result.Score,
                    Massage = "Your password is too easy",
                    Warning = result.Feedback.Warning,
                    Suggestions = result.Feedback.Suggestions

                };

            return new PasswordStrengthResult
            {
                Score = result.Score,
                Massage = "Good Password",
                Warning = result.Feedback.Warning,
                Suggestions = result.Feedback.Suggestions
            };

        }
        public async Task<int> UserExistsInSystem(LoginDetails user)
        {
            int res = await _repository.UserExistsInDb(user);
            if (res == default(int))
                return -1;


            else
                return await _repository.UserExistsInDb(user);
        }
        public async Task UpdateUserInSystem(int id, User userToUpdate)
        {
            await _repository.UpdateUserInDb(id, userToUpdate);
        }
    }
}
