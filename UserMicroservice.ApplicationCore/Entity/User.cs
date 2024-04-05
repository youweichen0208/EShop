using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public  class User
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(30, MinimumLength = 1)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain alphabetic characters.")]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20, MinimumLength = 6)]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password can only contain alphanumeric characters.")]
    public string Password { get; set; } = null!;
    
    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be 10 digit numbers.")]
    public string Phone { get; set; }
}
