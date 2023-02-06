using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public sealed class UserRegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirmed { get; set;}
    }
}
