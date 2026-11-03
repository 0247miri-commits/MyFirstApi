using Entities;
using System.Text.Json;



namespace Repository
{
    public class UserRepository
    {
        public UserDetails? GetUserFromFile(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("file.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserDetails? user = JsonSerializer.Deserialize<UserDetails>(currentUserInFile);
                    if (user.UserId == id)
                        return user;

                }
                //When no user has this id
                return null;
            }
        }


        public bool UniqueEmail(string email)
        {
            using (StreamReader reader = System.IO.File.OpenText("file.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserDetails user = JsonSerializer.Deserialize<UserDetails>(currentUserInFile);
                    if (user.Email == email)
                        return false;

                }
                return true;
            }
        }
        public void InsertUserToFile(UserDetails user)
        {
            int numberOfUsers = System.IO.File.ReadLines("file.txt").Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("file.txt", userJson + Environment.NewLine);
        }
        public int UserExistsInFile(LoginDetails loginDetails)
        {
            using (StreamReader reader = System.IO.File.OpenText("file.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserDetails user = JsonSerializer.Deserialize<UserDetails>(currentUserInFile);
                    if (user.Email == loginDetails.Email && user.Password == loginDetails.Password)
                        return user.UserId;
                }
                return -1;
            }
        }


        public void UpdateUserInFile(int id, UserDetails userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("file.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserDetails user = JsonSerializer.Deserialize<UserDetails>(currentUserInFile);
                    if (user.UserId == id)
                    {
                        textToReplace = currentUserInFile;
                        break;
                    }
                }
            }

            if (textToReplace != string.Empty)
            {
                //Keep the id, otherwise the updated user is saved without it
                userToUpdate.UserId = id;
                string text = System.IO.File.ReadAllText("file.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("file.txt", text);
            }
        }


    }
}
