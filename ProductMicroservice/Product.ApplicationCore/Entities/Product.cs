using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string Name { get; set; }
    
    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid decimal number.")]
    public decimal Price { get; set; }
    
    [Required]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
    public int Quantity { get; set; }
    [Required]
    public string Category { get; set; }
    public string Description { get; set; }
    
    [Required]
    public string Image { get; set; }
    [Required]
    public int SellerId { get; set; }
}