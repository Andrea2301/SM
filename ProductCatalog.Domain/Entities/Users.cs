namespace ProductCatalog.Domain.Entities;

public class Users
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    
    public ICollection<Product> Products { get; set; }
    
}