namespace ApplicationCore.Models;

public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int SellerId { get; set; }
}