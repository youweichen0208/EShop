using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers;
[Route("/api/shippers")]
[ApiController]
public class ShipperController : Controller
{
    private readonly IShipperService _shipperService;
    private readonly IMapper _mapper;
    public ShipperController(IShipperService shipperService, IMapper mapper)
    {
        _shipperService = shipperService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult GetAllShippers()
    {
        var shippers = _shipperService.GetAllShippers().ToList().Select(s => new { ShipperName = s.Name });
        return Ok(shippers);
    }

    [HttpGet("{id}")]
    public IActionResult GetShipperById(int id)
    {
        var shipper = _shipperService.GetShipperById(id);
        if (shipper == null)
            return NotFound();
        return Ok(shipper);
    }
    
    [HttpPost]
    public IActionResult AddShipper([FromBody] ShipperDto shipperDto)
    {
        var shipper = _mapper.Map<Shipper>(shipperDto);
        var addedShipper = _shipperService.AddShipper(shipper);
        return CreatedAtAction(nameof(GetShipperById), new { id = addedShipper.Id }, addedShipper);
    }
    
}