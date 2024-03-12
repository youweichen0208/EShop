using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.Controllers;

public class SignupController: Controller
{
    protected readonly ICustomerRepository _customerRepository;

    public SignupController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Customer customer)
    {
        Console.WriteLine("Email is " + customer.Email);
        if (ModelState.IsValid)
        {
            _customerRepository.Add(customer);
        }
        return Content("Register Successful!");
    }
}