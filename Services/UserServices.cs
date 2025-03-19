using MiniShop.Models;
using MiniShop.Models.Enums;
using MiniShop.Data;
namespace MiniShop.Services
{
    public class UserServices
    {
        private readonly MiniShopContext _shopContext;


      public UserServices(MiniShopContext shopContext)
        {
            _shopContext = shopContext; 
        }


            public void AddClient(Client user)
             { 
               _shopContext.Add(user);
            _shopContext.SaveChanges();
             }

          public void AddAdmin(Admin user)
            {
              _shopContext.Add(user);
            _shopContext.SaveChanges();
            }





        public void DeletUser(User user)
           {
             _shopContext.Remove(user);
            _shopContext.SaveChanges();
            }


        public List<User> GetUsers()
        {
            return _shopContext.User.ToList();
        }



    }
}
