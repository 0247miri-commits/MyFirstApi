using Entities;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Zxcvbn;


namespace Service
{
    public class UserService
    {
        private UserRepository _repository = new UserRepository();

        public UserDetails? GetUser(int id)
        {

           return _repository.GetUserFromFile(id);
            
        }
        public bool VaildPassword(UserDetails user)
        {
            var result = Core.EvaluatePassword(user.Password);

            if (result.Score < 3)
                return false;
            return true;
        }
        public bool UniqueUser(UserDetails user)
        {
            
            if (!_repository.UniqueEmail(user.Email))
                return false;
            return true;
            
        }
        public void InsertUser(UserDetails user)
        {
           _repository.InsertUserToFile(user);
        }
        public PasswordStrengthResult PasswordStrong(string password)
        {
            var result = Core.EvaluatePassword(password);
            if (result.Score < 3)
                return new PasswordStrengthResult
                {
                    Score = result.Score,
                    Message = "Your password is too easy",
                    Warning = result.Feedback.Warning,
                    Suggestions = result.Feedback.Suggestions

                };

            return new PasswordStrengthResult
            {
                Score = result.Score,
                Message = "Good Password",
                Warning = result.Feedback.Warning,
                Suggestions = result.Feedback.Suggestions
            };

        }
        public int UserExistsInSystem(LoginDetails user)
        {
           return _repository.UserExistsInFile(user);
        }
        public void UpdateUserInSystem(int id,  UserDetails userToUpdate)
        {
            _repository.UpdateUserInFile(id, userToUpdate);
        }
    }
}
