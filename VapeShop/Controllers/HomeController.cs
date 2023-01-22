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
            {
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная Ёмкость аккумулятора: 900",
                    Name = "Rincoe Jellybox Nano 2 Pod Kit 26W 900mAh",
                    Price = 1990,
                    PathToImage = @"/img/products/Pod/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 750",
                    Name = "Smoant Charon Baby POD Kit 750 mah with картридж Charon Baby",
                    Price = 1890,
                    PathToImage = @"/img/products/Pod/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 850",
                    Name = "Набор Elf Bar Elfa D20 10W 850mAh",
                    Price = 650,
                    PathToImage = @"/img/products/Pod/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная Ёмкость аккумулятора: 650",
                    Name = "Rincoe Jellybox F Pod Kit 15W 650mAh",
                    Price = 1190,
                    PathToImage = @"/img/products/Pod/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная Ёмкость аккумулятора: 1000",
                    Name = "Smoant Charon Baby Plus Pod Kit",
                    Price = 2290,
                    PathToImage = @"/img/products/Pod/5.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 900",
                    Name = "Набор Voopoo V Thru Pro",
                    Price = 2250,
                    PathToImage = @"/img/products/Pod/6.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная Ёмкость аккумулятора: 1000",
                    Name = "Rincoe Jellybox Nano X Pod Kit 30W 1000mAh",
                    Price = 1890,
                    PathToImage = @"/img/products/Pod/7.jpg"
                },
            }
        }, new()
        {
            Name = "Картриджи POD",
            PathToImage = @"/img/category/category_pod_cartridge.jpg",
            Products = new List<Product>()
            {
                new()
                {
                    Amount = 10,
                    Description = "Сопротивление: 0.7 Ом",
                    Name = "Картридж Voopoo Vmate (V Thru Pro / Vmate Infinity / Vmate E)",
                    Price = 260,
                    PathToImage = @"/img/products/PodCartridge/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Teslacigs pod TPOD Картридж",
                    Price = 340,
                    PathToImage = @"/img/products/PodCartridge/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Сопротивление: 1.2 Ом",
                    Name = "Картридж Vaporesso XROS",
                    Price = 260,
                    PathToImage = @"/img/products/PodCartridge/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Suorin: Сменный Картридж Vagon",
                    Price = 340,
                    PathToImage = @"/img/products/PodCartridge/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Teslacigs pod TPOD Картридж",
                    Price = 260,
                    PathToImage = @"/img/products/PodCartridge/5.jpg"
                },
            }
        }, new()
        {
            Name = "Испарители",
            PathToImage = @"/img/category/category_vaporizers.jpg",
            Products = new List<Product>()
            {
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная",
                    Name = "Испаритель Smoant Mesh 0.6 Ом (Battlestar Baby / Charon Baby / Veer)",
                    Price = 230,
                    PathToImage = @"/img/products/Vaporizers/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Кальянная",
                    Name = "Испаритель Smoant S Series (Santi, Charon Baby Plus)",
                    Price = 230,
                    PathToImage = @"/img/products/Vaporizers/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "",
                    Price = 1450,
                    PathToImage = @"/img/products/Vaporizers/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная",
                    Name = "Smoant NI80 Coil Испаритель 1.2 Ом (Battlestar Baby / Charon Baby / Veer)",
                    Price = 230,
                    PathToImage = @"/img/products/Vaporizers/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Смешанная",
                    Name = "Испаритель Smoant Pasito 2 / Knight 80 (K серия)",
                    Price = 290,
                    PathToImage = @"/img/products/Vaporizers/5.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная",
                    Name = "Испаритель Smoant S3 1.2 Ом (Santi, Charon Baby Plus)",
                    Price = 230,
                    PathToImage = @"/img/products/Vaporizers/6.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная",
                    Name = "Испаритель Rincoe Jellybox Nano (Jellybox Series)",
                    Price = 250,
                    PathToImage = @"/img/products/Vaporizers/7.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная",
                    Name = "Wismec Испаритель WM03 Triple",
                    Price = 190,
                    PathToImage = @"/img/products/Vaporizers/8.jpg"
                },

            }
        }, new()
        {
            Name = "Одноразовые сигареты",
            PathToImage = @"/img/category/category_disposable.jpg",
            Products = new List<Product>()
            {
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Strawberry Watermelon Bubble Gum одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Tropical Rainbow Blast одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Strawberry Watermelon Peach одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Strawberry Mango одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Raspberry Watermelon одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/5.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar Ultra BC5000 Watermelon Ice одноразовая электронная сигарета с подзарядкой",
                    Price = 1450,
                    PathToImage = @"/img/products/Disposable/6.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar BC4000 Passionfruit Orange Guava одноразовая электронная сигарета с подзарядкой",
                    Price = 1290,
                    PathToImage = @"/img/products/Disposable/7.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Elf Bar BB3000 Cranberry Soda одноразовая электронная сигарета с подзарядкой",
                    Name = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Price = 1000,
                    PathToImage = @"/img/products/Disposable/8.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная Ёмкость аккумулятора: 650",
                    Name = "Elf Bar BC4000 Mango Peach одноразовая электронная сигарета с подзарядкой",
                    Price = 1290,
                    PathToImage = @"/img/products/Disposable/9.jpg"
                },
            }
        }, new()
        {
            Name = "Жидкость для вейпа",
            PathToImage = @"/img/category/category_liquid_vaping.jpg",
            Products = new List<Product>()
            {
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Мята PG/VG: 50/50 Объем: 10 мл",
                    Name = "Жидкость ReSalt Сладкая Мята Silver (10 мл)",
                    Price = 740,
                    PathToImage = @"/img/products/LiquidVaping/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Ментол PG/VG: 60/40 Объем: 100 мл",
                    Name = "Жидкость Joyeliq Ментол (100 мл)",
                    Price = 1190,
                    PathToImage = @"/img/products/LiquidVaping/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Табак PG/VG: 50/50 Объем: 10 мл",
                    Name = "Жидкость ReSalt Табак Silver (10 мл)",
                    Price = 740,
                    PathToImage = @"/img/products/LiquidVaping/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Манго PG/VG: 50/50 Объем: 10 мл",
                    Name = "Жидкость ReSalt Манго Silver (10 мл)",
                    Price = 740,
                    PathToImage = @"/img/products/LiquidVaping/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Манго PG/VG: 50/50 Объем: 30 мл",
                    Name = "Жидкость Frisco Salt Mango (30 мл)",
                    Price = 1190,
                    PathToImage = @"/img/products/LiquidVaping/5.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Вишня PG/VG: 60/40 Объем: 100 мл",
                    Name = "Жидкость Joyeliq Вишня (100 мл)",
                    Price = 1190,
                    PathToImage = @"/img/products/LiquidVaping/6.jpg"
                },new()
                {
                    Amount = 10,
                    Description = "Вкус: Ежевика PG/VG: 60/40 Объем: 100 мл",
                    Name = "Жидкость Joyeliq Ежевика (100 мл)",
                    Price = 1190,
                    PathToImage = @"/img/products/LiquidVaping/7.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Вишня PG/VG: 50/50 Объем: 10 мл",
                    Name = "Жидкость ReSalt Вишня Silver (10 мл)",
                    Price = 740,
                    PathToImage = @"/img/products/LiquidVaping/8.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Яблоко / Зеленое яблоко PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Fruit Ninja Sour Apple 30 мл",
                    Price = 1350,
                    PathToImage = @"/img/products/LiquidVaping/9.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Персик PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Fruit Ninja Peach 30 мл",
                    Price = 1350,
                    PathToImage = @"/img/products/LiquidVaping/10.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Табак / Marlboro PG/VG: 60/40 Объем: 100 мл",
                    Name = "Жидкость Joyeliq USA Mix (100 мл)",
                    Price = 1190,
                    PathToImage = @"/img/products/LiquidVaping/11.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Ментол / Манго PG/VG: 50/50 Объем: 30 мл",
                    Name = "Жидкость Frisco Salt Mango Menthol (30 мл)",
                    Price = 1990,
                    PathToImage = @"/img/products/LiquidVaping/12.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Лед / Манго PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Fruit Ninja Mango Ice 30 мл",
                    Price = 1350,
                    PathToImage = @"/img/products/LiquidVaping/13.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Цитрус PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Fruit Ninja Citrus 30 мл",
                    Price = 1350,
                    PathToImage = @"/img/products/LiquidVaping/14.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Лед / Ананас PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Fruit Ninja Pineapple Ice 30 мл",
                    Price = 1350,
                    PathToImage = @"/img/products/LiquidVaping/15.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Marlboro / Табак PG/VG: 50/50 Объем: 10 мл",
                    Name = "Жидкость Joyeliq Salt USA Mix (10 мл)",
                    Price = 760,
                    PathToImage = @"/img/products/LiquidVaping/16.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Пончик / Клубника / Выпечка PG/VG: 60/40 Объем: 30 мл",
                    Name = "Жидкость Uncle Baker Strawberry Donut 30 мл",
                    Price = 1450,
                    PathToImage = @"/img/products/LiquidVaping/17.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Ягоды / Ягодный микс PG/VG: 50/50 Объем: 30 мл",
                    Name = "Жидкость Hangsen Salt Mixed Berries 30 мл",
                    Price = 1590,
                    PathToImage = @"/img/products/LiquidVaping/18.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Энергетик PG/VG: 50/50 Объем: 30 мл",
                    Name = "Жидкость Hangsen Salt Energy Drink 30 мл",
                    Price = 1590,
                    PathToImage = @"/img/products/LiquidVaping/19.jpg"
                }, 
                new()
                {
                    Amount = 10,
                    Description = "Вкус: Клубника / Арбуз PG/VG: 50/50 Объем : 30 мл",
                    Name = "Жидкость Hangsen Salt Strawberry Watermelon 30 мл",
                    Price = 750,
                    PathToImage = @"/img/products/LiquidVaping/20.jpg"
                },
            }
        }, new()
        {
            Name = "Вейпы",
            PathToImage = @"/img/category/category_vapes.jpg",
            Products = new List<Product>()
            {
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Eleaf: Набор Lexicon + ELLO Duro",
                    Price = 4990,
                    PathToImage = @"/img/products/Vapes/1.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Кальянная. Ёмкость аккумулятора: 2550",
                    Name = "Voopoo Drag E60 Pod Mod Kit 60W 2550mAh",
                    Price = 2990,
                    PathToImage = @"/img/products/Vapes/2.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Lost Vape Thelema Quest 200W Kit UB Pro Pod Tank",
                    Price = 4150,
                    PathToImage = @"/img/products/Vapes/3.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Eleaf iStick Pico Kit 21700 with ELLO 4000 mAh",
                    Price = 5590,
                    PathToImage = @"/img/products/Vapes/4.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Набор Vaporesso Armour Pro 100w",
                    Price = 3590,
                    PathToImage = @"/img/products/Vapes/5.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "",
                    Name = "Lost Vape Thelema Mini Pod Kit UB Lite Tank",
                    Price = 4490,
                    PathToImage = @"/img/products/Vapes/6.jpg"
                },
                new()
                {
                    Amount = 10,
                    Description = "Тип затяжки: Сигаретная. Ёмкость аккумулятора: 2000",
                    Name = "Vandy Vape Jackaroo Pod Kit 70W 2000mAh",
                    Price = 2990,
                    PathToImage = @"/img/products/Vapes/7.jpg"
                },
            }
        }, new()
        {
            Name = "Бокс моды",
            PathToImage = @"/img/category/category_box.jpg",
            Products = new List<Product>()
            {
                new()
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
            }
        });
        

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
        //var products = await _context.Products.Where(x => x.Discount > 0).ToListAsync();
        
        var model = new IndexViewModel
        {
            Categories = categories,
            NewProducts = products,
            Client = client
        };
        
        return View(model);
    }
    
    public async Task<IActionResult> Products(int idCategory)
    {
        var category = _context.Categorys
            .Include(x => x.Products)
            .FirstOrDefault(x => x.Id == idCategory);
        
        var list = category?.Products;
        var title = category?.Name;
        
        var email = User.Identity?.Name;
        Client? client = null;
        if (email != null)
        {
            client = await _context.Clients
                .Include(x => x.User)
                .Include(x => x.FavoriteProducts)
                .FirstOrDefaultAsync(x => x.User.Email == email);
        }
        var model = new ProductsViewModel
        {
            Title = title ?? "Товары",
            Client = client,
            Products = list ?? new List<Product>()
        };

        return View(model);
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Products(string? search)
    {
        var list = await _context.Products
            .Where(x => x.Name.ToLower().Contains(search == null ? "" : search.ToLower()))
            .ToListAsync();
        
        var email = User.Identity?.Name;
        Client? client = null;
        if (email != null)
        {
            client = await _context.Clients
                .Include(x => x.User)
                .Include(x => x.FavoriteProducts)
                .FirstOrDefaultAsync(x => x.User.Email == email);
        }

        var model = new ProductsViewModel
        {
            Title = "Результаты поиска",
            Client = client,
            Products = list
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