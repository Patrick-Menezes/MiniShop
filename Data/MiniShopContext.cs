using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Models;

namespace MiniShop.Data
{
    public class MiniShopContext : DbContext
    {
        public MiniShopContext (DbContextOptions<MiniShopContext> options)
            : base(options)
        {
        }

        public DbSet<MiniShop.Models.User> User { get; set; } = default!;
        public DbSet<MiniShop.Models.Product> Product{ get; set; } = default!;
      


    }
}
