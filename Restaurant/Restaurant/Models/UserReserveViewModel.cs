namespace Restaurant.Models
{
    public sealed class UserReserveViewModel
    {
        public string Email { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int CountOfSeats { get; set; }
    }
}
