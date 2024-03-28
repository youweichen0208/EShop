using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contract.Service;

namespace Product.API.Controller;
[ApiController]
[Route("/products")]
public class ProductController : ControllerBase
{
    private readonly IProductServiceAsync _productServiceAsync;
    [HttpGet]
    public async Task<IActionResult> RenderAllProducts()
    {
        var products = await _productServiceAsync.GetAllProducts();
        return Ok(products);
    }
}