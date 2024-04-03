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
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _userServiceAsync.GetAllCustomers();
        return Ok(customers);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetCustomerById(string email)
    {
        var customer = await _userServiceAsync.GetCustomerByEmail(email);
        return Ok(customer);
    }
    
}