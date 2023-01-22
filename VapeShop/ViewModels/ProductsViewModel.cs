using VapeShop.Models;

namespace VapeShop.ViewModels;

public class ProductsViewModel
{
    
    public string Title { get; set; }
    public ICollection<Product> Products { get; set; }
    
    public Client? Client { get; set; }
}