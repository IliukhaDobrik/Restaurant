using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUserDishService _userDishService;
        private readonly IUserService _userService;

        public BasketController(IUserDishService userDishService, IUserService userService)
        {
            _userDishService = userDishService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await GetBasket();
            return View(basket);
        }

        public async Task<IActionResult> AddToBasket(Guid dishId)
        {
            await _userDishService.Add(new UserDishDto
            {
                DishId = dishId,
                UserEmail = HttpContext.User.Identity.Name
            });
            return RedirectToAction("ViewMenu", "Menu");
        }

        private async Task<BasketViewModel> GetBasket()
        {
            var user = await _userService.GetByEmail(HttpContext.User.Identity.Name);
            var dishesDto = await _userDishService.GetById(user.UserId);

            var dishesForModel = new List<DishViewModel>();
            foreach (var dish in dishesDto)
            {
                dishesForModel.Add(new DishViewModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    ImageUrl = dish.ImageUrl
                });
            }
            return new BasketViewModel { Order = dishesForModel };
        }
    }
}
