namespace MiniShop.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int ClientId {  get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }

        public WishList() { }

        public WishList(int id, int clientId, int productId) 
        { 
         Id= id;
         ClientId= clientId;
         ProductId= productId;
        }



    }
}
