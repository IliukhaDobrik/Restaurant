using BussinesLayer.Dtos;
using BussinesLayer.Helpers.EmailSenders.Interfaces;
using BussinesLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IUserDishService _userDishService;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;

        public BasketController(IUserDishService userDishService, IUserService userService, IEmailSender emailSender)
        {
            _userDishService = userDishService;
            _userService = userService;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await GetBasket();
            if (basket.Order.Count == 0) 
            {
                ViewBag.Error = "Корзина пуста, вы бомж";
                return RedirectToAction("Error");
            }
            return View(basket);
        }

        public async Task<IActionResult> AddToBasket(Guid dishId)
        {
            await _userDishService.Add(new UserDishRequestDto
            {
                DishId = dishId,
                UserEmail = HttpContext.User.Identity.Name
            });
            return RedirectToAction("ViewMenu", "Menu");
        }

        public async Task<IActionResult> RemoveFromBasket(Guid dishId)
        {
            await _userDishService.Delete(dishId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Error(string errorMasssage)
        {
            return View(errorMasssage);
        }

        public async Task<IActionResult> Pay()
        {
            var user = await _userService.GetByEmail(User.Identity.Name);
            var userDishes = await _userDishService.GetById(user.UserId);
            decimal price = 0;

            var basket = await GetBasket();
            foreach (var item in basket.Order)
            {
                price+= item.Price;
            }

            foreach(var item in userDishes)
            {
                await _userDishService.Delete(item.DishId);
            }

            _emailSender.Send(price, User.Identity.Name);

            return RedirectToAction("Index");
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
                    DishId = dish.DishId,
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
