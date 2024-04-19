using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repositories;
using Order.Infrastructure.Contexts;

namespace Order.Infrastructure.Repositories;
using Order.ApplicationCore.Entities;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private readonly OrderDbContext _orderDbContext;
    public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task<Order?> RetrieveOrderById(int id)
    {
        return await _orderDbContext.Set<Order>().Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id==id);
    }

    public async Task<List<Order>> GetOrdersById(int id)
    {
        var orders = await _orderDbContext.Set<Order>().Where(order => order.CustomerId == id).ToListAsync();
        return orders;
    }
}