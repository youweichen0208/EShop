using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Contracts.Services;

namespace User.API.Controllers;

[Route("/api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userServiceAsync)
    {
        _userService = userServiceAsync;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var customers = await _userService.GetAllUsers();
        return Ok(customers);
    }
}