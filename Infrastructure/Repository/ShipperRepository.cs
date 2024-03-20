using ApplicationCore.Contracts;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
{
    public ShipperRepository(ShippingDbContext context) : base(context)
    {
    }
}