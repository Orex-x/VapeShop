using VapeShop.Models;

namespace VapeShop.ViewModels;

public class IndexViewModel
{ 
    public ICollection<Category> Categories { get; set; }
    
    public ICollection<Product> NewProducts { get; set; }
    
    public Client? Client { get; set; }
}