namespace Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<Order?> RetrieveOrderById(int id);

    public Task<List<Order>> GetOrdersById(int id);
}