using System.Diagnostics;
using ApplicationCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shipping.Models;

namespace Shipping.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerRepository _customerRepository;

    public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        var isValid = _customerRepository.Login(username, password);
        if (isValid)
        {
            var s = _customerRepository.FindByEmail(username)?.Name;
            if (s != null)
            {
                HttpContext.Session.SetString("user", s);
            }

            return RedirectToAction("Index", "Customer");    
        }
        
        ViewBag.LoginError = "Login Failed. Please double check your email and password.";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}