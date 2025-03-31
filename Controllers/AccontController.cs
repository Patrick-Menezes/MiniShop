using Microsoft.AspNetCore.Mvc;
using MiniShop.Models;
using MiniShop.Services;
using MiniShop.Models.ViewModels;

namespace MiniShop.Controllers
{
    public class AccontController : Controller
    {
        private readonly UserServices _userServices;
        public AccontController(UserServices userServices)
        {
           _userServices = userServices;
        }

        public IActionResult Login()
        {
            return View();
        }


        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(); // Se os dados não forem válidos, retorna a view com erros de validação.
            }


            var users = _userServices.GetUsers();

            var user = users.FirstOrDefault(u => u.Email == Model.Email && u.Password == Model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "E-mail ou senha inválidos.");
                return View(Model); // Retorna à tela de login com erro
            }


   
            if (user.UserType == Models.Enums.UserType.Admin)
            {
                return RedirectToAction("Dashboard", "Admin", new
                {
                    name = user.Name,
                    email = user.Email,
                    userType = user.UserType.ToString()
                });
            }

            return RedirectToAction("Index", "Store", new
            {
                Id= user.Id,
                name = user.Name,
                email = user.Email,
                userType = user.UserType.ToString()
            });


        }
         
        

        public IActionResult Register()
        {
            return View();
        } 



        public IActionResult Users()
        {
           var users = _userServices.GetUsers();

            return View(users);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult CreateClient(Client client) 
       {

            _userServices.AddClient(client);
            return RedirectToAction("Login", "Accont");
        }


    }

}
