using Microsoft.AspNetCore.Mvc;

using MiniShop.Models;
using MiniShop.Models.ViewModels;
using MiniShop.Services;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace MiniShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StoreService _storeService;
        
        public AdminController(StoreService storeService, IWebHostEnvironment webHostEnvironment)
        {
            _storeService = storeService;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Dashboard(string name , string email, string usertype)
        {
            var userviewModel = new UserViewModel
            {
                Email = email,
                Name = name,
                UserType = usertype
            };

            return View(userviewModel);




        }



        public IActionResult Products() 
        {
             
            var products = _storeService.GetProducts();

            return View(products);
        
        
        }

        public IActionResult AddProducts()
        { 
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageUrls = new List<string>();

            if (model.Images != null && model.Images.Count > 0)
            {

                // Caminho para a pasta "uploads"
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                // Verifica se a pasta existe, se não, cria
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }



                foreach (var image in model.Images)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    imageUrls.Add("/uploads/" + fileName);
                }
            }

            var produto = new Product
            {
               
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrls = imageUrls
            };

            _storeService.AddProduct(produto);

            return RedirectToAction("Products");
        }









    }






    }

