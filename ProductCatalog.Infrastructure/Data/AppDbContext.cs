using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Data;

public class AppDbContext : DbContext
{
    
    public DbSet<Product>  Products { get; set; }
    public DbSet<Users>  Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
        
    }
}