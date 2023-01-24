using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Reserve(UserRequestDto user)
        {

        }

    }
}
