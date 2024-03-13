using Microsoft.AspNetCore.Mvc;

namespace Shipping.Controllers;

public class CustomerController:Controller
{
    public IActionResult Index()
    {
        Console.WriteLine("Session name is " + HttpContext.Session.GetString("user"));
        return View();
    }
}