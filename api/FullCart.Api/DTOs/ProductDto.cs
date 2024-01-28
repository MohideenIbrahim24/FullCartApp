namespace FullCart.Api;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public string? Category { get; set; }
    public Guid BrandId { get; set; }
    public string? Brand { get; set; }
}
