using MiniShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniShop.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MiniShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniShopContext") ?? throw new InvalidOperationException("Connection string 'MiniShopContext' not found.")));

// Habilita sessão no projeto
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); // Necessário para usar sessões



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<StoreService>();





var app = builder.Build();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
