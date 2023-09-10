using Microsoft.EntityFrameworkCore;

namespace api_crud;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  public DbSet<Product> Products { get; set; }
}
