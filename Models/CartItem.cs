using Microsoft.Data.SqlClient.DataClassification;

namespace MiniShop.Models
{
    public class CartItem
    {

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount {  get; set; }

        public CartItem() { }

        public CartItem(int id, Product product, int amount)
        {
            Id = id;
            Product = product;
            Amount = amount;
        }
    }
}
