using System.Security;

namespace VapeShop.Models;

public class Client : BaseEntity
{
    public User User { get; set; }
    
    public int Balance { get; set; }

    public ICollection<Product> FavoriteProducts { get; set; }
    
    public ICollection<ProductBasket> Basket { get; set; }
}