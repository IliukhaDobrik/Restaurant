namespace Entities
{
    public sealed class User
    {
        public Guid UserId { get; set; }
        public Guid? PlaceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfReservation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserDishes> UserDishes { get; set; }
        public Place Place { get; set; }
    }
}