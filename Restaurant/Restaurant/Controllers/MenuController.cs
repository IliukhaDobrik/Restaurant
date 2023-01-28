using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;

        public MenuController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
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
