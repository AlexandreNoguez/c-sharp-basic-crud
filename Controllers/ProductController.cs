using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api_crud;

[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
  private readonly IProductRepository _productRepository;
  public ProductController(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  [HttpGet]
  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _productRepository.Get();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    return await _productRepository.Get(id);
  }

  [HttpPost]
  public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
  {
    var newProduct = await _productRepository.Create(product);
    return newProduct;
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteProduct(int id)
  {
    var productToDelete = await _productRepository.Get(id);

    if (productToDelete == null)
    {
      return NotFound(); // Retorna 404 se o produto não for encontrado.
    }

    await _productRepository.Delete(id);
    return NoContent();
  }


  [HttpPut]
  public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
  {
    if (id == product.Id)
    {
      await _productRepository.Update(product);
      return NoContent();
    }
    else
    {
      throw new Exception("Product not found!");
    }
  }

}
