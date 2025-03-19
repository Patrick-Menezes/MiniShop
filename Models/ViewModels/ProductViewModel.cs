namespace MiniShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

      
        public List<IFormFile> Images { get; set; }
    }
}
