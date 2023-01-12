using Core.DTOs;
using Entities.Models;
namespace Business.Interfaces;
public interface IServiceDtoProductCatName : IService<Product>
{
    IQueryable<DtoProductCatName> GetProductsCatName();
    IQueryable<Product> GetProductsByCatergory(int prdId);
}