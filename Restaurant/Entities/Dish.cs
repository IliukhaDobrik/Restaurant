namespace Entities
{
    public sealed class Dish
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<UserDishes> UserDishes { get; set; }
    }
}
