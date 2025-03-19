namespace MiniShop.Models;
using Models.Enums;
public class Admin  : User
{
    public Admin() { }
    public Admin(int id, string name, string email, string password)
    : base(id, name, email, password, UserType.Admin)
    { }
}
