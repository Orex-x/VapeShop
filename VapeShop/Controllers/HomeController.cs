using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Models;
using VapeShop.ViewModels;

namespace VapeShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;

    public HomeController(ILogger<HomeController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void UpData()
    {
        _context.Categorys.AddRange(new Category
        {
            Name = "POD-системы",
            PathToImage = @"/img/category/category_pod.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Картриджи POD",
            PathToImage = @"/img/category/category_pod_cartridge.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Испарители",
            PathToImage = @"/img/category/category_vaporizers.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Одноразовые сигареты",
            PathToImage = @"/img/category/category_disposable.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Жидкость для вейпа",
            PathToImage = @"/img/category/category_liquid_vaping.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Вейпы",
            PathToImage = @"/img/category/category_vapes.jpg",
            Products = new List<Product>()
        }, new()
        {
            Name = "Бокс моды",
            PathToImage = @"/img/category/category_box.jpg",
            Products = new List<Product>()
        });
       

        _context.Products.AddRange(
            //box
            new Product
            {
                Amount = 10,
                Description = "",
                Name = "Мод Lost Vape Thelema Solo 100W",
                Price = 3050,
                PathToImage = @"/img/products/Box/1.jpg"
            },
            new()
            {
                Amount = 10,
                Description = "",
                Name = "Voopoo Drag 3 Mod 177W",
                Price = 3690,
                PathToImage = @"/img/products/Box/2.jpg"
            },
            new()
            {
                Amount = 10,
                Description = "Батарейный (200W, без аккумуляторов)",
                Name = "Мод Voopoo Argus GT 2",
                Price = 3790,
                PathToImage = @"/img/products/Box/3.jpg"
            }, new()
            {
                Amount = 10,
                Description = "(100W, без аккумулятора)",
                Name = "Мод Geekvape S100 Aegis Solo 2",
                Price = 3590,
                PathToImage = @"/img/products/Box/4.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Мод Vaporesso GEN 200",
                Price = 2990,
                PathToImage = @"/img/products/Box/5.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Lost Vape Centaurus Q200 TC Mod 200W",
                Price = 3950,
                PathToImage = @"/img/products/Box/6.jpg"
            }, new()
            {
                Amount = 10,
                Description = "Батарейный",
                Name = "Мод Eleaf iStick Pico 75W Simple",
                Price = 2550,
                PathToImage = @"/img/products/Box/7.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Lost Vape Thelema Quest TC Mod 200W",
                Price = 3500,
                PathToImage = @"/img/products/Box/8.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Voopoo Argus MT Mod 100W",
                Price = 3950,
                PathToImage = @"/img/products/Box/9.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Мод Hellvape Hell200 200W",
                Price = 4100,
                PathToImage = @"/img/products/Box/10.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Класс А Вейп 1000",
                Price = 2000,
                PathToImage = @"/img/products/Box/11.jpg"
            }, new()
            {
                Amount = 10,
                Description = "",
                Name = "Мод Geekvape M100 Aegis Mini 2 (100W, 2500 mAh)",
                Price = 4150,
                PathToImage = @"/img/products/Box/12.jpg"
            }
            //Disposable
           
        );

    _context.SaveChanges();
    }

    
    public async Task<IActionResult> Index()
    {
        var email = User.Identity?.Name;
        Client? client = null;
        if (email != null)
        {
            client = await _context.Clients
                .Include(x => x.User)
                .Include(x => x.FavoriteProducts)
                .FirstOrDefaultAsync(x => x.User.Email == email);
        }
        
        var categories = await _context.Categorys.ToListAsync();
        var products = await _context.Products.ToListAsync();
        
        var model = new IndexViewModel
        {
            Categories = categories,
            NewProducts = products,
            Client = client
        };
        
        return View(model);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}