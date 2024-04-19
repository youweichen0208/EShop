namespace Order.ApplicationCore.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    
    public int OrderId { get; set;}
    public Order Order { get; set; }
    
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    public string Image { get; set; }
}