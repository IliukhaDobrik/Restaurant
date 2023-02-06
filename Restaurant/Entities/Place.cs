namespace Entities
{
    public sealed class Place
    {
        public Guid PlaceId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? DateOfReservation { get; set; }
        public int CountOfSeats { get; set; }
        public int SeatNumber { get; set; }
        public User User { get; set; }
    }
}
