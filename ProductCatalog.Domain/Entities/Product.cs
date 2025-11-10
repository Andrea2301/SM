namespace ProductCatalog.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
    public int UsersId { get; set; }
    public Users users  { get; set; }
}