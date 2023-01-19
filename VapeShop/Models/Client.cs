namespace VapeShop.Models;

public class Client : BaseEntity
{
    public User User { get; set; }
    
    public int Balance { get; set; }
}