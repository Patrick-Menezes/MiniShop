using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Models;
using MiniShop.Services;

namespace MiniShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserServices _userServices;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , UserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Users()
        {
            var Users = _userServices.GetUsers();

            return View(Users);
        }



    }
}
