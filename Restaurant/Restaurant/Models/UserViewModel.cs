using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfReservation { get; set; }
        public int? NumberOfSet { get; set; }
    }
}
