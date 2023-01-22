namespace VapeShop.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    
    public string PathToImage { get; set; }
    
    public ICollection<Product> Products { get; set; }
}