using Microsoft.EntityFrameworkCore;
using MiniShop.Data;
using MiniShop.Models;

namespace MiniShop.Services
{
    public class StoreService
    {
        private readonly MiniShopContext _context;
        private readonly UserServices _userServices;

        public StoreService(MiniShopContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }


        public IEnumerable<Product> GetProducts()
        {

            return _context.Products.ToList();


        }


        public Product GetProduct(int Id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == Id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public void AddCartItens(int ClientId,int ProductId,int Amount)
        {



            var user = _userServices.GetUser(ClientId) as Client;

            if (user == null)
                throw new Exception("Cliente não encontrado!");

            var cartItem = new CartItem()
            {
                ClientId = ClientId,
                ProductId = ProductId,
                Amount = Amount
            };

            user.AddItemCart(cartItem); // Adiciona à lista ShoppingCart

            _context.Update(user); // Marca o Client como modificado para rastrear as mudanças

            _context.SaveChanges(); // Salva no banco


        }


        public bool AddWishP(int ClientId, int ProductId)
        {
            // Busca o usuário com a lista de desejos carregada
            var user = _context.Users.OfType<Client>()
                .Include(c => c.WishList) // Carrega a lista de desejos do cliente
                .FirstOrDefault(c => c.Id == ClientId);

            if (user == null)
                throw new KeyNotFoundException("Cliente não encontrado!");

            var productExists = _context.Products.Any(p => p.Id == ProductId);
            if (!productExists)
                throw new KeyNotFoundException("Produto não encontrado!");

            // Verifica se o produto já está na lista de desejos do cliente
            if (user.WishList.Any(w => w.ProductId == ProductId))
                return false;

            // Adiciona à lista de desejos
            var wishList = new WishList
            {
                ClientId = ClientId,
                ProductId = ProductId
            };

            user.WishList.Add(wishList);

            try
            {
                _context.SaveChanges(); // Salva as mudanças no banco
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a lista de desejos.", ex);
            }
        }


        public IEnumerable<WishList> GetWishLists(int clientId)
        {
            return _context.WishLists
                .Include(w => w.Product)  // Carregar os produtos junto com a lista de desejos
                .Where(w => w.ClientId == clientId)
                .ToList();
        }


    }
}

