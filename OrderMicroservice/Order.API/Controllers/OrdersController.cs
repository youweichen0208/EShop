using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models;

namespace Order.API.Controllers;
using Order.ApplicationCore.Entities;
[Route("/orders")]
[ApiController]
public class OrdersController : ControllerBase
{

    private readonly IOrderService _orderService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly HttpClient _httpClient;
    public OrdersController(IOrderService orderService, IOrderDetailService orderDetailService, HttpClient httpClient)
    {
        _orderService = orderService;
        _orderDetailService = orderDetailService;
        _httpClient = httpClient;
    }

    [HttpGet("/orders/users/{id}")]
    public async Task<IActionResult> GetOrderHistory(int id)
    {
        var order = await _orderService.GetOrderHistory(id);
        return Ok(order);
    }
    
    
    [HttpGet("/orders/{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null) return NotFound("Order Not Found");
        var result = new
        {
            number = order.OrderNumber,
            date = order.CreatedTime,
            address = order.ShipAddress,
            city = order.ShipCity,
            state = order.ShipState,
            country = order.ShipCountry,
            postalCode = order.ShipPostalCode,
            items = order.OrderDetails,
        };
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDto orderDto)
    {
        
        var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var easternTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, easternZone);
        var order = new Order
        {
            CustomerId = orderDto.UserId,
            ShipAddress = orderDto.Address.Address,
            ShipCity = orderDto.Address.City,
            OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper(),
            ShipState = orderDto.Address.State,
            CreatedTime = easternTime,
            ShipPostalCode = orderDto.Address.Zip.ToString(),
            ShipCountry = orderDto.Address.Country,
            OrderDetails = orderDto.Items.Select(item => new OrderDetail
            {
                ProductId = item.Id,
                Quantity = item.Quantity,
                Price = item.Price,
                Image = item.Image,
            }).ToList()
        };
        var createdOrder = await _orderService.CreateOrder(order);
        Console.WriteLine("order id is " + createdOrder.Id);
        CreateOrderResponseDto responseDto = new CreateOrderResponseDto { OrderId = createdOrder.Id };
        return Ok(responseDto);
    }
}