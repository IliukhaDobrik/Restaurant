using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Runtime.InteropServices;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper) 
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(UserViewModel userViewModel)
        {
            var user = _mapper.Map<UserRequestDto>(userViewModel);
            await _userService.Add(user);
            return RedirectToAction("Reserve");
        }
    }
}
