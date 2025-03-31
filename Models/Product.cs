namespace MiniShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }     
        public List<string> ImageUrls { get; set; }=new List<string>();
        public List<WishList> WishLists { get; set; } = new List<WishList>();
        public Product()
        {

        }

        public Product(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }



        public void AddImage(string imageUrl)
        {
            ImageUrls.Add(imageUrl);
        }
        public void RemoveImage(string imageUrl) {
            ImageUrls.Remove(imageUrl);
             }
    }
}
