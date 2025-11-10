using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application;

public class ProductService
{
    private readonly IProductRepository  _productRepository;

    ///dependency injection
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    //-------------------Services for products----------------------//

    // List all products
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }
    
    //list producst by ID

    public async Task<Product> GetProductById(int id)
    {
        return await _productRepository.GetProductById(id);
    }
    
    // Create a new product
    public async Task<Product> AddProduct(Product product)
    {
        await _productRepository.AddProduct(product);
        return product;
    }
    
    //update a product

    public async Task<bool> UpdateProduct(Product product)
    {
        var exits = await _productRepository.GetProductById(product.Id);
        
        if (exits == null)
         return false;
        
        await _productRepository.UpdateProduct(product);
        return true;
    }
    // Delete a product 
    public async Task<bool> DeleteProduct(int id)
    {
        var exits = await _productRepository.GetProductById(id);
        if (exits == null)
            return false;
        await _productRepository.DeleteProduct(id);
        return true;
    }
    
    
}