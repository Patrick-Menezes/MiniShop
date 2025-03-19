using Microsoft.AspNetCore.Mvc;
using MiniShop.Models.ViewModels;
using System.Drawing;

namespace MiniShop.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index(String name , string email, string userType)
        {
            var userViewModel = new UserViewModel
            {
                Name = name,
                Email = email,
                UserType = userType
            };



            return View(userViewModel);
        }
    }
}
