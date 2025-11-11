using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application;
using ProductCatalog.Application.Dtos;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }


    // get products by ID
    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
       var  product = await _productService.GetProductById(id);

       if (product == null)
           return NotFound(new { message = $"product with {id} not found "});
       return Ok(product);
    }
    
    // get all products 

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }
    
    // Create a new product 

    [HttpPost("Create")]

    public async Task<IActionResult> AddProduct([FromBody] ProductCreateDto productDto) //[FromBody] force the Web API to read a simple type from the request body
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        // Map The DTO to model
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price

        };
        
        var createdProduct = await _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }
    
    
    //Update a product By ID
    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductCreateDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exits = await _productService.GetProductById(id);
        if (exits ==null)
            return NotFound(new { message = $"Product with ID {id} not found" });
        
        exits.Name = productDto.Name;
        exits.Description = productDto.Description;
        exits.Price = productDto.Price;
        
        var updatedProduct = await _productService.UpdateProduct(exits);
        
        if (!updatedProduct)
            return StatusCode(500,new { message = $"Error updating product with ID {id}" });
        return NoContent();
    }
    
    // Delete product by ID
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var DeletedProduct = await _productService.DeleteProduct(id);
        
        if (!DeletedProduct)
            return NotFound(new { message = $"Product with ID {id} not found" });
        return Ok(DeletedProduct);
    }
}