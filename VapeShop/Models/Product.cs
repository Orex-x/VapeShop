namespace VapeShop.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public int Price { get; set; }
    
    public int Discount { get; set; }
    public string PathToImage { get; set; }
    
    public int NumberSales { get; set; }
}