using System.ComponentModel.DataAnnotations;

namespace MyApiProject
{
    public class PasswordToCheck
    {
        
    
        public required string Password { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
    }
}
