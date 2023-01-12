using Business.Interfaces;
using Core.DTOs;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceDtoProductCatName
            : Service<Product>, IServiceDtoProductCatName
{
    private readonly IDalDtoProductCatName prodCatName;
    public ServiceDtoProductCatName(IEntityRepo<Product> entityRepo,
        IDalDtoProductCatName pProdCatName) : base(entityRepo) 
                    => prodCatName = pProdCatName;
    public IQueryable<DtoProductCatName> GetProductsCatName()
                    => prodCatName.GetProductsCatName();
    public IQueryable<Product> GetProductsByCatergory(int prdId)
                    => prodCatName.GetProductsByCatergory(prdId);
}