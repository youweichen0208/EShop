namespace Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
public interface IOrderService
{
    Task<Order?> GetOrderById(int id);
    Task<Order> CreateOrder(Order order);

    Task<List<Order>> GetOrderHistory(int id);
}