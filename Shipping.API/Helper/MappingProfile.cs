using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;

namespace Shipping.API.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}