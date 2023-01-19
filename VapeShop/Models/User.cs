namespace VapeShop.Models;

public class User : BaseEntity
{
    public string Login { get; set; }
    
    public string Password { get; set; }
}