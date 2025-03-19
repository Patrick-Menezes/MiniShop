
namespace MiniShop.Models;
using MiniShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class User
    {

         public int Id { get; set; }
         [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [Required]
        private string _Password { get; set; }
       

      public string Password 
      {
        get {  return _Password; }
        set
        {
            if (value.Length != 8)
            {
                throw new ArgumentException("A senha deve conter 8 caracteres.");
            }
            _Password = value;
        }
    
    
      }

      public User() { }
    public User(int id, string name, string email, string password, UserType userType)
    { 
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        UserType = userType;
    
    }



    }

