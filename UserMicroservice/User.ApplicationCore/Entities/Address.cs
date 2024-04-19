using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.ApplicationCore.Entities;

public class Address
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string StreetAddress {get; set;}

    [Required]
    public string Unit {get; set;}

    [Required]
    public string City {get; set;}

    [Required]
    public string State {get; set;}

    [Required]
    public string Country {get; set;}

    [Required]
    [RegularExpression("^[0-9]{1,10}$", ErrorMessage = "Invalid Zip Code")]
    public int ZipCode {get; set;}

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
}