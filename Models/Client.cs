namespace MiniShop.Models;
using Models.Enums;
    public class Client:User
    {
    public Client() { }
    public Client(int id , string name , string email,string password)
        :base(id , name , email, password,UserType.Client)
             { }




    public List<CartItem> ShoppingCart {  get; set; }=new List<CartItem>();
    public List<WishList> WishList { get; set; }= new List<WishList>();

    public List<Order> Orders{ get;set; }=new List<Order>();


    public void AddItemCart(CartItem cartItem)
    {
        ShoppingCart.Add(cartItem); 
    }
    public void AddOrder(Order order)
    {
     Orders.Add(order);
    }
    public void AddWishItem(WishList wishList)
    {
        WishList.Add(wishList);
    }

    public void RemoveWishItem(WishList wishList)
        {
        WishList.Remove(wishList);

        }




    }

