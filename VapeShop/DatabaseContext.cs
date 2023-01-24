using Microsoft.EntityFrameworkCore;
using VapeShop.Models;

namespace VapeShop;

public class DatabaseContext : DbContext
{
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ShopPoint> ShopPoints { get; set; }
    
    public DbSet<ProductBasket> ProductBaskets { get; set; }

    public DatabaseContext()
    {
        try
        {
            Database.EnsureCreated();
        }
        catch (Exception)
        {
            // ignored
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "host=localhost;port=5432;database=VapeShop;username=postgres;password=333");
    }
}