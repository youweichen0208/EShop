using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using User.ApplicationCore.Contracts.Services;
using User.ApplicationCore.Models;

namespace User.API.Controllers;
using User.ApplicationCore.Entities;
[Route("")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AccountController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("/signup")]
    public async Task<IActionResult> Register(SignupDto? signupDto)
    {
        Console.WriteLine("Invalid register");
        if (signupDto == null) return StatusCode(500, "User Creation Failed");
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(signupDto.Password);
        signupDto.Password = hashedPassword;
        User user = new User
        {
            Email = signupDto.Email,
            Password = signupDto.Password,
            Name = signupDto.Name,
            Phone = signupDto.Phone
        };
        await _userService.CreateUser(user);
        return Ok(new {msg="user register successfully"});
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserDto form)
    {
        var user = await _userService.Login(form.Email);
        if (user == null) return NotFound("the account or password is incorrect.");

        var token = CreateToken(user);
        return Ok(new { id = user.Id, name = user.Name, jwtToken = token, expiresIn = DateTime.Now.AddMinutes(120) });
    }


    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new("name", user.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], claims,
            expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}