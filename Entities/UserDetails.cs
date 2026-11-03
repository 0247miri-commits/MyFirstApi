using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public  class UserDetails
    {
        [EmailAddress]
        public required string Email { get; set; }


        public required string Password { get; set; }


        [StringLength(20, MinimumLength = 2, ErrorMessage = "שם פרטי חייב להיות לפחות 2 תווים.")]
        public required string FirstName { get; set; }


        [StringLength(20, MinimumLength = 2, ErrorMessage = "שם משפחה חייב להיות לפחות 2 תווים.")]
        public required string LastName { get; set; }

        public int UserId { get; set; }
    }
}
