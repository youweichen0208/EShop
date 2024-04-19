using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Services;

public class OrderDetailService : IOrderDetailService
{
    public Task<OrderDetail> GetOrderDetail(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderDetail(OrderDetail orderDetail)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderDetail(int id)
    {
        throw new NotImplementedException();
    }
}