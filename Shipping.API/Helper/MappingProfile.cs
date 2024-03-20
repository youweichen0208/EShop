using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.Services;

namespace Shipping.API.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<Shipper, ShipperDto>();
        CreateMap<ShipperDto, Shipper>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ShipperName))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.ShipperState));

    }
}