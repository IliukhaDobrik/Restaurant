namespace BussinesLayer.Dtos
{
    public sealed class UserDishRequestDto
    {
        public string UserEmail { get; set; }
        public Guid DishId { get; set; }
    }
}
