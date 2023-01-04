using AutoMapper;
using Core.DTOs;
using Entities.Models;
namespace Core.Helper;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, DtoCategory>().ReverseMap();
        CreateMap<Customer, DtoCustomer>().ReverseMap();
        CreateMap<Employee, DtoEmployee>().ReverseMap();
        CreateMap<Product, DtoProduct>().ReverseMap();
        CreateMap<Region, DtoRegion>().ReverseMap();
        CreateMap<Shipper, DtoShipper>().ReverseMap();
        CreateMap<Supplier, DtoSupplier>().ReverseMap();
        CreateMap<Territory, DtoTerritory>().ReverseMap()
            .ForMember(dest => dest.Region,
                opt => opt.MapFrom(src => src.Region));
    }
}