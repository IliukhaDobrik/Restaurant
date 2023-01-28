using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class BasketController : Controller
    {
        private readonly IDishService _dishService;

        public BasketController(IDishService dishService)
        {
            _dishService = dishService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToOrder(Guid id)
        {
            //что-то придумать с basket
            var basket = new BasketViewModel();
            var dish = await _dishService.GetById(id);
            var dishViewModel = new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                ImageUrl = dish.ImageUrl
            };

            basket.Order.Add(dishViewModel);
            return View(basket);
        }
    }
}
