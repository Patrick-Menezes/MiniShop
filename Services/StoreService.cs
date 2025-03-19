using MiniShop.Data;
using MiniShop.Models;

namespace MiniShop.Services
{
    public class StoreService
    {
        private readonly MiniShopContext _context;

    public StoreService(MiniShopContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetProducts()
        {
        
         return _context.Product.ToList();
        
        
        }

        public void AddProduct(Product product)
        { 
            _context.Product.Add(product);
            _context.SaveChanges();
        }

       







    }
}
