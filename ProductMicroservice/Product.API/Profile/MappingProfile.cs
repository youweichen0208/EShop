namespace ProductAPI.Profile;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}