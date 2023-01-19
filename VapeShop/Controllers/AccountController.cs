using Microsoft.AspNetCore.Mvc;
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
    }
}
