using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contract.Service;

namespace Product.API.Controller;
[ApiController]
[Route("/products")]
public class ProductController : ControllerBase
{
    private readonly IProductServiceAsync _productServiceAsync;
    private readonly HttpClient _httpClient;
    public ProductController(IProductServiceAsync productServiceAsync, HttpClient httpClient)
    {
        _productServiceAsync = productServiceAsync;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7257");
    }
    [HttpGet]
    public async Task<IActionResult> RenderAllProducts()
    {
        // var products = await _productServiceAsync.GetAllProducts();
        HttpResponseMessage result = await _httpClient.GetAsync("/api/users");
        if (result.IsSuccessStatusCode)
        {
            var c = await result.Content.ReadFromJsonAsync<IEnumerable<User>>();
            return Ok(c);
        }
        return BadRequest(result.StatusCode);
    }
}