using Microsoft.Data.SqlClient.DataClassification;
using MiniShop.Models;

namespace MiniShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // Apenas o ID do Produto
        public int Amount { get; set; }
        public int ClientId { get; set; }   // Apenas o ID do Cliente

        public CartItem() { }

        public CartItem(int id, int productId, int amount, int clientId)
        {
            Id = id;
            ProductId = productId;
            Amount = amount;
            ClientId = clientId;
        }
    }

}