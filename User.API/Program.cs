using CustomerMicroservice.ApplicationCore.Contract.Repository;
using CustomerMicroservice.ApplicationCore.Contract.Service;
using CustomerMicroservice.Infrastructure.Context;
using CustomerMicroservice.Infrastructure.Repository;
using CustomerMicroservice.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

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
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
