using AutoMapper;
using Entities.DTOs;
using Entities.Models;
namespace Entities.Helper;
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
        .ForMember(m => m.Region, opt => opt.MapFrom(src => src.Region));
    }
}