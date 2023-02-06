namespace Entities
{
    public sealed class UserDishes
    {
        public Guid UserDishesId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? DishId { get; set; }
        public User User { get; set; }
        public Dish Dish { get; set; }
    }
}
