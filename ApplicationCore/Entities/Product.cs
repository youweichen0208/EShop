namespace ApplicationCore.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryID { get; set; }
    public decimal ProductPrice { get; set; }
    
    public string ProductSeller { get; set; }
    
    
    
}