using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Contracts.Services;

namespace Order.Infrastructure.Services;
using Order.ApplicationCore.Entities;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Order?> GetOrderById(int id)
    {
       var order = await _orderRepository.RetrieveOrderById(id);
       return order;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        var result = await _orderRepository.Add(order);
        return result;
    }

    public async Task<List<Order>> GetOrderHistory(int id)
    {
        var orders = await _orderRepository.GetOrdersById(id);
        return orders;
    }
}