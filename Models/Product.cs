namespace api_crud;

public class Product
{
  public int Id { get; set; }

  public required string Name { get; set; }

  public required string Description { get; set; }

  public int Quantity { get; set; }
}
