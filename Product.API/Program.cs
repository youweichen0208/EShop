using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contract.Repository;
using ProductMicroservice.ApplicationCore.Contract.Service;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repository;
using ProductMicroservice.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ProductDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("Eshop"));
});
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


