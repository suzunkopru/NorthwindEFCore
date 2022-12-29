using Entities.DTO;
using Entities.Models;
namespace DataAccess.Interfaces;
public interface IDalDtoProductCatName : IEntityRepo<Product>
{
    IQueryable<DtoProductCatName> GetProductsCatName();
    IQueryable<Product> GetProductsByCatergory(int prdId);
}