using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api_crud;

public interface IProductRepository
{
  Task<IEnumerable<Product>> Get();

  Task<Product> Get(int Id);

  Task<Product> Create(Product product);

  Task Update(Product product);

  Task Delete(int Id);
}
