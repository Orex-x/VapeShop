using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Models;

namespace VapeShop.Controllers;

public class OrderController : Controller
{
    private readonly DatabaseContext _context;
        
    public OrderController(DatabaseContext context)
    {
        _context = context;
    }

    [Authorize]
    public IActionResult PayOrder() => View();

    
    [Authorize]
    public async Task<RedirectToActionResult> CreateOrder()
    {
        var email = User.Identity?.Name;
        var client = await _context.Clients
            .Include(x => x.User)
            .Include(x => x.Orders)
            .ThenInclude(x => x.Products)
            .Include(x => x.Basket)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.User.Email == email);

        var sumWithDiscount  = client.Basket.Select(x => x.Amount * x.Product?.Price * (100 - x.Product?.Discount) / 100).Sum();
        
        var order = new Order
        {
            Products = new List<ProductBasket>(),
            DateTime = DateTime.Now,
            OrderStatus = OrderStatus.Collecting,
            Price = sumWithDiscount ?? 0
        };

        foreach (var productBasket in client.Basket)
        {
            order.Products.Add(productBasket);
        }
        
        client.Orders.Add(order);
        client.Basket.Clear();
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        
        
        return RedirectToAction("AccountClient", "Account");
    }
}