using CustomerMicroservice.ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controller;

[Route("")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserServiceAsync _userServiceAsync;

    public AccountController(IUserServiceAsync userServiceAsync)
    {
        _userServiceAsync = userServiceAsync;
    }
    
    [HttpPost("/signup")]
    public async Task<IActionResult> Register(User? user)
    {
        Console.WriteLine(user);
        if (user == null) return StatusCode(500, "User Creation Failed");
        await _userServiceAsync.CreateUser(user);
        return Ok("Success");
    }
}