namespace MiniShop.Models;
using Models.Enums;
    public class Client:User
    {
    public Client() { }
    public Client(int id , string name , string email,string password)
        :base(id , name , email, password,UserType.Client)
             { }

    public List<CartItem> ShoppingCart {  get; set; }=new List<CartItem>();
    public List<Product> WhishList { get; set; }= new List<Product>();

    public List<Order> Orders{ get;set; }=new List<Order>();    







    }

