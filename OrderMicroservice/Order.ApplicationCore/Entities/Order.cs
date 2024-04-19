namespace Order.ApplicationCore.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string OrderNumber { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipState { get; set; }
    public DateTime CreatedTime { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

}