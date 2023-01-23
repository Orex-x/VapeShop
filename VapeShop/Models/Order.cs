using VapeShop.ViewModels;

namespace VapeShop.Models;

public class Order : BaseEntity
{
    public OrderStatus OrderStatus { get; set; }
    
    public ICollection<ProductBasket> Products { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public int Price { get; set; }
}