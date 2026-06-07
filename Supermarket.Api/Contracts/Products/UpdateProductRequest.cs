namespace Supermarket.Api.Contracts.Products;
public class UpdateProductRequest
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }
}
