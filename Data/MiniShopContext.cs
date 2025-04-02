using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MiniShop.Models;

namespace MiniShop.Data;

public class MiniShopContext : DbContext
{
    public MiniShopContext (DbContextOptions<MiniShopContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Client>("Client")
            .HasValue<Admin>("Admin");
    }

    public DbSet<User>Users { get; set; } = default!;
    public DbSet<Product> Products{ get; set; } = default!;
    public DbSet<CartItem> CartItems { get; set; } = default!;
    public DbSet<Order> Orders { get; set; }= default!;

    public DbSet<WishList> WishLists { get; set; }




}
