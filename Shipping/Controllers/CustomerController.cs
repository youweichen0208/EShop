using ApplicationCore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.Controllers;

public class CustomerController:Controller
{
    private readonly IProductRepository _productRepository;

    public CustomerController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IActionResult Index(int page = 1)
    {
        if (page < 1)
            page = 1;
        var productList = _productRepository.pagination(page);
        
        ViewData["user"] = HttpContext.Session.GetString("user");
        ViewBag.page = page;
        return View(productList);
    }
}