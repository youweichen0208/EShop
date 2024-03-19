using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index(int? page)
    {
        if (page.HasValue && page > 0)
        {
            var products = _productRepository.pagination(page.Value).ToList();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
        else
        {
            var allProducts = _productRepository.GetAll().ToList();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(allProducts);
            return Ok(productDtos);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        var productDto = _mapper.Map<ProductDto>(product);


        return Ok(productDto);
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] ProductDto? productDto)
    {
        if (productDto == null)
        {
            return BadRequest("Product cannot be null");
        }

        var product = _mapper.Map<Product>(productDto);
        Product addedProduct = _productRepository.Add(product);
        return CreatedAtAction(nameof(GetProductById), new { id = addedProduct.ProductId }, productDto);
    }
}