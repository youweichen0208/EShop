namespace ProductMicroservice.ApplicationCore.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public int SellerId { get; set; }
}