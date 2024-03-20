using ApplicationCore.Contracts;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class ShipperService : IShipperService
{
    private readonly IShipperRepository _shipperRepository;

    public ShipperService(IShipperRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }
    public IEnumerable<Shipper> GetAllShippers()
    {
        return _shipperRepository.GetAll();
    }

    public Shipper? GetShipperById(int id)
    {
        return _shipperRepository.GetById(id);
    }

    public Shipper AddShipper(Shipper shipper)
    {
        return _shipperRepository.Add(shipper);
    }

    public void UpdateShipper(Shipper shipper)
    {
        _shipperRepository.Update(shipper);
    }

    public void DeleteShipper(int id)
    {
        _shipperRepository.Delete(id);
    }
}