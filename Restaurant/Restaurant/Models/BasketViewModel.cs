namespace Restaurant.Models
{
    public sealed class BasketViewModel
    {
        public List<DishViewModel> Order { get; set; } = new List<DishViewModel>();
    }
}
