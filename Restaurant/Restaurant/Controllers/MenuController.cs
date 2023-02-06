using BussinesLayer.Interfaces;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDishService _dishService;

        public MenuController(IDishService dishService)
        {
            _dishService = dishService;
        }

        public async Task<IActionResult> ViewMenu()
        {
            try
            {
                var dishes = _dishService.GetAll().Result.ToList();

                var dishViewModels = dishes.Select(x => new DishViewModel
                {
                    DishId = x.DishId,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl
                }).ToList();

                return View(dishViewModels);
            }
            catch (ObjectNotExistExepcion)
            {
                return RedirectToAction("MenuIsEmpty");
            }
        }

        public async Task<IActionResult> MenuIsEmpty() => View();
    }
}
