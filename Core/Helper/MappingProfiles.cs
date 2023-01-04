using AutoMapper;
using Core.DTOs;
using Entities.Models;
using DtoOrder = Core.DTOs.DtoOrder;

namespace Core.Helper;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, DtoCategory>().ReverseMap();
        CreateMap<Customer, DtoCustomer>().ReverseMap();
        CreateMap<Employee, DtoEmployee>().ReverseMap();
        CreateMap<DtoOrder, DtoOrder>().ReverseMap();
        CreateMap<Product, DtoProduct>().ReverseMap(); 
        CreateMap<Region, DtoRegion>().ReverseMap();
        CreateMap<Shipper, DtoShipper>().ReverseMap();
        CreateMap<Supplier, DtoSupplier>().ReverseMap();
        CreateMap<Territory, DtoTerritory>().ReverseMap()
        .ForMember(terr => terr.Region,
            opt => opt.MapFrom(dto => dto.Region));
    }
}