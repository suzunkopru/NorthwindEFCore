using Core.DTOs;
using Entities.Models;
namespace DataAccess.Interfaces;
public interface IServiceDtoProductCatName : IService<Product>
{
    IQueryable<DtoProductCatName> GetProductsCatName();
    IQueryable<Product> GetProductsByCatergory(int prdId);
}