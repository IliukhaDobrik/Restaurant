using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Entities;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(UserReserveViewModel userViewModel)
        {
            var user = _mapper.Map<UserReserveDto>(userViewModel);
            int seatNumber;
            try
            {
                seatNumber = await _userService.ReservePlace(user);
            }
            catch (ObjectNotExistExepcion)
            {
                return RedirectToAction("SeatNotFound");
            }
            return RedirectToAction("ReserveComplete", new {@seatNumber = seatNumber});
        }

        public async Task<IActionResult> SeatNotFound()
        {
            return View();
        }
        
        public async Task<IActionResult> ReserveComplete(int? seatNumber)
        {
            return View(seatNumber);
        }
    }
}
