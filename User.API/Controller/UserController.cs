using CustomerMicroservice.ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controller;

[Route("/api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserServiceAsync _userServiceAsync;
    public UserController(IUserServiceAsync userServiceAsync)
    {
        _userServiceAsync = userServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var customers = await _userServiceAsync.GetAllUsers();
        return Ok(customers);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetUserById(string email)
    {
        var customer = await _userServiceAsync.GetUserByEmail(email);
        return Ok(customer);
    }
}