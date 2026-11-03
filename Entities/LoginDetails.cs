using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LoginDetails
    {
        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "הסיסמא חייבת להיות לפחות 4 תווים.")]
        public required string Password { get; set; }

    }
}
