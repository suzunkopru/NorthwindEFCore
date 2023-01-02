using AutoMapper;
using Entities.Models;
using UIBlazor.DTOs;
namespace UIBlazor.Helper;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, DtoCategory>();
        CreateMap<Customer, DtoCustomer>();
        CreateMap<Employee, DtoEmployee>();
        CreateMap<Product, DtoProduct>();
        CreateMap<Region, DtoRegion>();
        CreateMap<Shipper, DtoShipper>();
        CreateMap<Supplier, DtoSupplier>();
        CreateMap<Territory, DtoTerritory>();
    }
}