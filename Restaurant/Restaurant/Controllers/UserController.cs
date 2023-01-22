using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IPlaceRepository _userRepository;

        public UserController(IPlaceRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult GetUsers()
        {
            var users = _userRepository.GetAll().AsEnumerable();
            return View(users);
        }

        public async Task<IActionResult> Change()
        {
            Guid guid = new Guid("DB3C8EDD-1D7D-4891-8D22-D1B83005DE3A");

            await _userRepository.Delete(guid);
            await _userRepository.Save();

            return RedirectToAction("Index");
        }
    }
}
