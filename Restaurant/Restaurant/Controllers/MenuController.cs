using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IDishService _dishService;

        public MenuController(IDishService dishService)
        {
            _dishService = dishService;
        }

        public async Task<IActionResult> ViewMenu()
        {
            List<DishRequestDto> dishes;
            try
            {
                dishes = await _dishService.GetAll();
            }
            catch (ObjectNotExistExepcion)
            {
                return RedirectToAction("MenuIsEmpty");
            }
            
            var dishesViewModels = new List<DishViewModel>();
            foreach(var dish in dishes)
            {
                dishesViewModels.Add(new DishViewModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    ImageUrl = dish.ImageUrl
                });
            }
            return View(dishesViewModels);
        }

        public async Task<IActionResult> MenuIsEmpty()
        {
            return View();
        }
    }
}
