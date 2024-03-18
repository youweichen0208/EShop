using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public IActionResult Index(int? page)
    {
        if (page.HasValue && page > 0)
        {
            var products = _productRepository.pagination(page.Value);
            return Ok(products);
        }
        else
        {
            var allProducts = _productRepository.GetAll();
            return Ok(allProducts);
        }
    }
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    
    [HttpPost]
    public IActionResult AddProduct([FromBody]Product product)
    {
        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }

        _productRepository.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }
    
    
}