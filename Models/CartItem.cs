using Microsoft.Data.SqlClient.DataClassification;
using MiniShop.Models;

namespace MiniShop.Models
{
  
        public class CartItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }  // ID do Produto
            public int Amount { get; set; }     // Quantidade
            public int ClientId { get; set; }   // ID do Cliente

            // Propriedade para armazenar o produto, útil se estiver usando EF
            public required Product Product { get; set; }

            // Propriedade calculada para o preço total
            public decimal TotalPrice => Product != null ? Product.Price * Amount : 0;

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


