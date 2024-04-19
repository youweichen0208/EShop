namespace Order.ApplicationCore.Models;

public class OrderDto
{
    public int UserId { get; set; }
    public List<CartItemDto> Items { get; set; }
    public AddressDto Address { get; set; }
    
}