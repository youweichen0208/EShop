using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    [Range(1,3, ErrorMessage = "Category ID must be between 1 and 3")]
    public int CategoryID { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductSeller { get; set; }
    public Category Category { get; set; }
}