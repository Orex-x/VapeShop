using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.Models;

namespace VapeShop.Controllers;

public class BasketController : Controller
{
    
    private readonly DatabaseContext _context;
        
    public BasketController(DatabaseContext context)
    {
        _context = context;
    }
    
    
    [Authorize]
    public async Task<IActionResult> Basket()
    {
        var email = User.Identity?.Name;

        var client = await _context.Clients
            .Include(x => x.User)
            .Include(x => x.Basket)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.User.Email == email);
            
        return View(client);
    }
    
    [Authorize]
    public async Task<RedirectToActionResult> AddProductInBasket(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        var email = User.Identity?.Name;
        var client = await _context.Clients
            .Include(x => x.Basket)
            .FirstOrDefaultAsync(x => x.User.Email == email);
       
        if (client != null)
        {
            client.Basket.Add(new ProductBasket
            {
                Amount = 1,
                Product = product,
            });
            
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Basket", "Basket");
    }
    
    [Authorize]
    public async Task<RedirectToActionResult> RemoveProductInBasket(int id)
    {
        var basketProduct = await _context.ProductBaskets.FirstOrDefaultAsync(x => x.Id == id);
        if (basketProduct != null)
        {
            _context.ProductBaskets.Remove(basketProduct);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Basket", "Basket");
    }
}