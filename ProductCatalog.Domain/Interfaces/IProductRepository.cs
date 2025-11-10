using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Interfaces;

public interface IProductRepository 
{
    Task<Product> GetProductById(int id);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int id);
}