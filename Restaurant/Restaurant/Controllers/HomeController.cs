using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About() => View();
    }
}