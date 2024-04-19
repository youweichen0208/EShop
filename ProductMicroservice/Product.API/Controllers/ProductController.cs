using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;

[ApiController]
[Route("/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
        this._productService = productService;
        this._mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok("products successfully!");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetail(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound("Product Not Found.");
        return Ok(product);
    }
    
    
    [HttpGet("/product-names/{id}")]
    public async Task<IActionResult> GetProductNameById(int id)
    {
        var name = await _productService.GetProductNameById(id);
        return Ok(new {name=name});
    }
    [HttpGet("/categories/{category}")]
    public async Task<IActionResult> GetProductsByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return BadRequest("Category cannot be empty");
        }
        category = char.ToUpperInvariant(category[0]) + category.Substring(1);
        List<Product>? products;
        if (category ==  "All")
        {
            products = await _productService.GetAllProducts();
        }
        else
        {
            products = await _productService.GetProductsByCategory(category);
        }
        if (products == null)
            return BadRequest("error page");
        List<ProductDto> list = products.Select(product => _mapper.Map<ProductDto>(product)).ToList(); 
        return Ok(list);
    }

    [HttpGet("/product-list/{name}")]
    public async Task<IActionResult> GetProductsByName(string name)
    {
        var product = await _productService.GetProductByName(name);
        if (product == null)
        {
            return NotFound("Product Not Found");
        }

        return Ok(new {id=product.Id});
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(Product product)
    {
        var result = await _productService.RegisterProduct(product);
        if (result == true)
            return Ok(new {msg="Product Uploaded Successfully!"});
        else
            return BadRequest("Sorry product uploading failed");
    }
}