using AutoMapper;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BussinesLayer.Helpers.EmailSenders.Interfaces;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IEmailSender emailSender, IMapper mapper) 
        {
            _userService = userService;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Reserve() => View();

        [HttpPost]
        public async Task<IActionResult> Reserve(UserReserveViewModel userViewModel)
        {
            var user = _mapper.Map<UserReserveDto>(userViewModel);
            try
            {
                var (seatNumber, DateOfReserve) = await _userService.ReservePlace(user);
                await _emailSender.Send(seatNumber, DateOfReserve, User.Identity.Name);
                return RedirectToAction("ReserveComplete", new { @seatNumber = seatNumber });
            }
            catch (ObjectNotExistExepcion)
            {
                return RedirectToAction("SeatNotFound");
            }
        }

        public async Task<IActionResult> SeatNotFound() => View();
        
        public async Task<IActionResult> ReserveComplete(int? seatNumber) => View(seatNumber);
    }
}
