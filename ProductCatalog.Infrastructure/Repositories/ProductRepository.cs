using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}