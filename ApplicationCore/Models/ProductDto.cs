namespace ApplicationCore.Models;

public class ProductDto
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryID { get; set; }
    public string ProductSeller { get; set; }
}