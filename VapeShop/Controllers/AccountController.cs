using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VapeShop.Models;

namespace VapeShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;
        
        public AccountController(DatabaseContext context)
        {
            _context = context;
        }
        
        public IActionResult Authorization() => View();
        public IActionResult Registration() => View();
        
        [Authorize]
        public async Task<IActionResult> AccountClient()
        {
            var email = User.Identity?.Name;

            var client = await _context.Clients
                .Include(x => x.User)
                .Include(x => x.FavoriteProducts)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Products)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.User.Email == email);
            
            return View(client);
        }
        
        
        [Authorize]
        public async Task<RedirectToActionResult> UpdateFavoriteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                var email = User.Identity?.Name;
                var client = await _context.Clients
                    .Include(x => x.FavoriteProducts)
                    .FirstOrDefaultAsync(x => x.User.Email == email);
       
                if (client != null)
                {
                    var _ = client.FavoriteProducts.FirstOrDefault(x => x.Id == id);
                    if (_ == null)
                        client.FavoriteProducts.Add(product);
                    else
                        client.FavoriteProducts.Remove(product);   
                    
                    _context.Clients.Update(client);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("AccountClient", "Account");
        }
        

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (findUser != null) return View(model);
            
            if (model.Password.Length > 7)
            {
                var hasher = new PasswordHasher<User>();

                var user = new User
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    LastName = model.LastName,
                    Login = model.Login,
                    Email = model.Email,
                };
                user.Password = hasher.HashPassword(user, model.Password);
                await Authenticate(user.Email);

                var client = new Client
                {
                    User = user,
                    Balance = 0,
                    FavoriteProducts = new List<Product>(),
                    Basket = new List<ProductBasket>(),
                    Orders = new List<Order>()
                };
                        
                await _context.Clients.AddAsync(client);
                await  _context.SaveChangesAsync();
                return RedirectToAction("AccountClient", "Account");
            }
            ModelState.AddModelError("", "Пароль должен содержать минимум 8 символов");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Authorization(AuthorizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    var hasher = new PasswordHasher<User>();
                    var s = hasher.VerifyHashedPassword(user, user.Password, model.Password);

                    if (s == PasswordVerificationResult.Success)
                    {
                        await Authenticate(user.Email);
                        return RedirectToAction("AccountClient", "Account");
                    }
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AccountClient", "Account");
        }
    }
}
