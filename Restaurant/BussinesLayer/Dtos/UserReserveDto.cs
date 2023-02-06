namespace BussinesLayer.Dtos
{
    public sealed class UserReserveDto
    {
        public string Email { get; set; }
        public DateTime DateOfReservation { get; set; }
        public int CountOfSeats { get; set; }
    }
}
