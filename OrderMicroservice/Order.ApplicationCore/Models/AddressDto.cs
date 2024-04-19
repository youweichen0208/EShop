namespace Order.ApplicationCore.Models;

public class AddressDto
{
    public string Address { get; set; }
    public string Unit { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int Zip { get; set; }
}