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
using MimeKit;
using Restaurant.Models;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Runtime.InteropServices;
using MailKit.Security;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IEmailService emailService, IMapper mapper) 
        {
            _userService = userService;
            _emailService = emailService;
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
            try
            {
                var (seatNumber, DateOfReserve) = await _userService.ReservePlace(user);
                await _emailService.Send(seatNumber, DateOfReserve, User.Identity.Name);
                return RedirectToAction("ReserveComplete", new { @seatNumber = seatNumber });
            }
            catch (ObjectNotExistExepcion)
            {
                return RedirectToAction("SeatNotFound");
            }
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
