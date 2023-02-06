using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public sealed class UserLoginViewModel
    {
        [Required(ErrorMessage = "Не указан email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль!")]
        public string Password { get; set; }
    }
}
