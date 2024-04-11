using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CustomerMicroservice.ApplicationCore.Contract.Service;
using CustomerMicroservice.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Customer.API.Controller;

[Route("")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserServiceAsync _userServiceAsync;
    private readonly IConfiguration _configuration;

    public AccountController(IUserServiceAsync userServiceAsync, IConfiguration configuration)
    {
        _userServiceAsync = userServiceAsync;
        _configuration = configuration;
    }
    
    [HttpPost("/signup")]
    public async Task<IActionResult> Register(User? user)
    {
        if (user == null) return StatusCode(500, "User Creation Failed");
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = hashedPassword;
        await _userServiceAsync.CreateUser(user);
        return Ok("Success");
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserDto form)
    {
        var user = await _userServiceAsync.Login(form.Email);
        if (user == null)
            return NotFound("the account or password is incorrect.");
        else
        {
            string token = CreateToken(user);
            return Ok(new {name=user.Name, jwtToken=token, expiresIn=DateTime.Now.AddMinutes(120)});
        }
    }


    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("name", user.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],claims: claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    
}