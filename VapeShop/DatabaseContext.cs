﻿using Microsoft.EntityFrameworkCore;
using VapeShop.Models;

namespace VapeShop;

public class DatabaseContext : DbContext
{
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<HR> HRs { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<User> Users { get; set; }

    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "host=localhost;database=VapeShop;username=postgres;password=123");
    }
}