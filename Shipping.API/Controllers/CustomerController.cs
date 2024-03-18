using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers;

[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    protected readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        var customers = _customerRepository.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _customerRepository.GetById(id);
        if (customer == null)
            return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult RegisterCustomer([FromBody] Customer? customer)
    {
        if (customer == null)
            return BadRequest();
        _customerRepository.Add(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }
    
    
}