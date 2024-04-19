using Microsoft.EntityFrameworkCore;
using Reviews.ApplicationCore.Contracts.Repositories;
using Reviews.ApplicationCore.Contracts.Services;
using Reviews.Infrastructure.Contexts;
using Reviews.Infrastructure.Repositories;
using Reviews.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ReviewsDbContext>(option =>
{
    // option.UseSqlServer(Environment.GetEnvironmentVariable("Eshop"));
    option.UseSqlServer(builder.Configuration.GetConnectionString("EshopDB"));
});
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policy => 
    policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();