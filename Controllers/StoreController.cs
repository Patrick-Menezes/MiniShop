using Microsoft.AspNetCore.Mvc;
using MiniShop.Models;
using MiniShop.Models.ViewModels;
using MiniShop.Services;
using System.Drawing;

namespace MiniShop.Controllers
{
    public class StoreController : Controller

    {
        private readonly StoreService _storeService;
        private readonly UserServices _userService;



        public StoreController(StoreService storeService ,UserServices userServices)
        {
            _storeService = storeService;
            _userService = userServices;

        }



        public IActionResult Index(int Id )
        {

          var products = _storeService.GetProducts();
            var User = _userService.GetUser( Id );
               
            var StoreViewModel  = new ShopViewModel
            {
               User = User,
                
                products = products.ToList(),
            };


            return View(StoreViewModel);
        }


        public IActionResult Details(int productId, int clientId)
        {

            var client = _userService.GetUser(clientId);
            var product = _storeService.GetProduct(productId);

            if (client == null)
            {
                throw new Exception("Cliente não encontrado!");
            }

            if (product == null)
            {
                throw new Exception("Produto não encontrado!");
            }


            var Product = new DetailViewModel
            {
                Client =   client,
                Product =  product
               
            };

            return View(Product);


        }

     

        
        [AutoValidateAntiforgeryToken]
         
        [HttpPost]
        public IActionResult AddToCart(int ProductId,int ClientId,int Amount)
        {

            _storeService.AddCartItens(ClientId,ProductId, Amount);

            return RedirectToAction("Index", new { Id = ClientId });

        }


        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult AddToWishlist(int ProductId, int ClientId )
        {
            if (ProductId <= 0 || ClientId <= 0)
            {
                return BadRequest("Parâmetros inválidos.");
            }

            _storeService.AddWishP(ClientId,ProductId);

            return RedirectToAction("Index", new { Id = ClientId });

        }

        public IActionResult Favorites(int ClientId)
        {

            var client = _userService.GetUser(ClientId);

            var wishList =_storeService.GetWishLists(ClientId);

            var viewModel = new WishViewModel
            {
                User = client,
                products = wishList.ToList()
            };

            return View(viewModel);

        }

        public IActionResult Cart(int ClientId)
        {
            var cartItems = _storeService.GetCartItem(ClientId);

            foreach (var item in cartItems)
            {
                var product = _storeService.GetProduct(item.ProductId); // Obtém o produto correspondente ao item
       
            }

            return View(cartItems);
        }


    }

}



