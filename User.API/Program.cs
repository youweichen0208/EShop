using System.Text;
using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.ApplicationCore.Contract.Service;
using CustomerMicroservice.Infrastructure.Context;
using CustomerMicroservice.Infrastructure.Repository;
using CustomerMicroservice.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<UserDbContext>(option =>
{
    // option.UseSqlServer(Environment.GetEnvironmentVariable("Eshop"));
    option.UseSqlServer(builder.Configuration.GetConnectionString("EshopDB"));
});
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>();

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());

// Use authentication
app.UseAuthentication();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.Run();