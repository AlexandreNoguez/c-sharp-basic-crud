
using Microsoft.EntityFrameworkCore;

namespace api_crud;

public class ProductRepository : IProductRepository
{
  public readonly ProductContext _context;
  public ProductRepository(ProductContext context)
  {
    _context = context;
  }
  public async Task<Product> Create(Product product)
  {
    _context.Products.Add(product);
    await _context.SaveChangesAsync();

    return product;
  }

  public async Task Delete(int id)
  {
    var productToDelete = await _context.Products.FindAsync(id);

    if (productToDelete != null) // Verifica se o produto não é nulo antes de tentar removê-lo.
    {
      _context.Products.Remove(productToDelete);
      await _context.SaveChangesAsync();
    }
    else
    {
      throw new Exception("Product not found!");
    }
  }

  public async Task<IEnumerable<Product>> Get()
  {
    return await _context.Products.ToListAsync();


  }

  public async Task<Product> Get(int id)
  {
    var findProduct = await _context.Products.FindAsync(id);

    if (findProduct != null)
    {
      return findProduct;
    }
    else
    {
      throw new Exception("Product not found!");
    }
  }

  public async Task Update(Product product)
  {
    _context.Entry(product).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }
}
