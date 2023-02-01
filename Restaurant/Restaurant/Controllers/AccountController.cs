﻿using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserDishService _userDishService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetByEmail(User.Identity.Name);
            try
            {
                var (seatNumber, dateOfReserve) = await _userService.GetPlace(user.UserId);
                return View(new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Password = user.Password,
                    NumberOfSet = seatNumber,
                    DateOfReservation = dateOfReserve
                });
            }
            catch (InvalidOperationException)
            {
                return View(new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Password = user.Password,
                    NumberOfSet = null,
                    DateOfReservation = null
                });
            }
        }
    }
}
