using System.ComponentModel.DataAnnotations;

namespace User.ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(31, MinimumLength = 1)]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain alphabetic characters or space.")]
    public string Name { get; set; }

    [Required] [EmailAddress] 
    public string Email { get; set; } 

    [Required] 
    public string Password { get; set; } 

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be 10 digit numbers.")]
    public string Phone { get; set; }
    
    public Address Address { get; set; }
}