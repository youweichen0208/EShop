using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Contracts.Services;
using User.ApplicationCore.Entities;
using User.ApplicationCore.Models;

namespace User.API.Controllers;

[Route("address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IUserService _userService;
    
    
    public AddressController(IAddressService addressService, IUserService userService)
    {
        _addressService = addressService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAddressByUserId(int userId)
    {
        var address = await _addressService.GetAddressByUserId(userId);
        if (address == null)
            return NotFound("Address Not Found");
        
        return Ok(new {address=address.StreetAddress, unit=address.Unit, city=address.City, state=address.State, zip=address.ZipCode, country=address.Country, userId=address.UserId});
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateUserAddress(AddressDto addressDto)
    {
        var user = await _userService.GetUserById(addressDto.UserId);
        if (user == null)
            return NotFound("User Id Not Found");

        var address = await _addressService.GetAddressByUserId(addressDto.UserId);
        if (address == null)
        {
            address = new Address
            {
                StreetAddress = addressDto.Address,
                Unit = addressDto.Unit,
                City = addressDto.City,
                State = addressDto.State,
                Country = addressDto.Country,
                ZipCode = addressDto.Zip,
                User = user
            };
        }
        else
        {
            address.StreetAddress = addressDto.Address;
            address.Unit = addressDto.Unit;
            address.City = addressDto.City;
            address.State = addressDto.State;
            address.Country = addressDto.Country;
            address.ZipCode = addressDto.Zip;
        }
        await _addressService.UpdateAddress(address);
        return Ok(new { message = "Address Update successfully!" });
    }
    
}