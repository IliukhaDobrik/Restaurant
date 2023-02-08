using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public sealed class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^(\+375|80)(\-?|\s)(29|25|33|44)(\-?|\s)(\d{3})(\-?|\s)(\d{2})(\-?|\s)(\d{2})$",
            ErrorMessage = "Неверный формат")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*\.[a-z]{2,6}$",
            ErrorMessage = "Неверный формат")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        //One uppercase later
        //One lowwercase later
        //One digital or one special symbol
        //Min lenght 8
        [RegularExpression(@"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",
            ErrorMessage = "Пароль должен содержать одну заглавную латинскую букву, одну прописную латинскую букву, либо одну цифру, либо один специальный символ. Минимальная длинна 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirmed { get; set;}
    }
}
