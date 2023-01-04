using AutoMapper;
using Entities.DTOs;
using Entities.Models;
namespace UIBlazor.Helper;
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
        CreateMap<Territory, DtoTerritory>().ReverseMap();
    }
}