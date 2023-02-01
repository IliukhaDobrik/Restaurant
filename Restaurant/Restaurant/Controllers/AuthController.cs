using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant.Models;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.CheckIdentity(viewModel.Email, viewModel.Password);

                if (user is not null)
                {
                    await Authenticate(viewModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некоректный логин и(или) пароль");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetByEmail(viewModel.Email);
                if (user is null)
                {
                    try
                    {
                        await _userService.Register(new UserDto
                        {
                            Email = viewModel.Email,
                            Password = viewModel.Password,
                            FirstName = viewModel.FirstName,
                            LastName = viewModel.LastName,
                            PhoneNumber = viewModel.PhoneNumber
                        });
                    }
                    catch (ObjectAlreadyExistExepcion)
                    {
                        return RedirectToAction("Login");
                    }
                    await Authenticate(viewModel.Email);
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные данные");
                }
            }
            return View(viewModel);
        }

        private async Task Authenticate(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "User")
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
