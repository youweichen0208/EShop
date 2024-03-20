using ApplicationCore.Entities;

namespace ApplicationCore.Contracts;

public interface IShipperService
{
    IEnumerable<Shipper> GetAllShippers();
    Shipper? GetShipperById(int id);
    Shipper? AddShipper(Shipper shipper);
    void UpdateShipper(Shipper shipper);
    void DeleteShipper(int id);
}