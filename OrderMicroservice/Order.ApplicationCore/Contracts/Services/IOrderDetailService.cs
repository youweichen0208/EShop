using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderDetailService
{
    Task<OrderDetail> GetOrderDetail(int id);
    Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrder(int orderId);
    Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
    Task UpdateOrderDetail(OrderDetail orderDetail);
    Task DeleteOrderDetail(int id);
}