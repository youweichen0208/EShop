using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.Controllers;

public class ProductController: Controller
{
    private static List<Product> _productList = new List<Product>
    {
        new Product { Category = "book", ProductId = 1, ProductPrice = 30, ProductName = "Comic Book" },
        new Product { Category = "Furniture", ProductId = 2, ProductName = "Sofa", ProductPrice = 1200},
    };

    public IActionResult Index()
    {
        return View(_productList);
    }

    public IActionResult DeleteById(int Id)
    {
        Product product = _productList.Where(s=> s.ProductId == Id).FirstOrDefault();
        _productList.Remove(product);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }
}