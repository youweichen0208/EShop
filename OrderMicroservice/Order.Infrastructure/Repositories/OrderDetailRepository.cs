using Order.ApplicationCore.Contracts.Repositories;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Contexts;

namespace Order.Infrastructure.Repositories;

public class OrderDetailRepository:BaseRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly OrderDbContext _orderDbContext;
    public OrderDetailRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }
}