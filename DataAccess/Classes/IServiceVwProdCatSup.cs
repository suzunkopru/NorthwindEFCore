using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class IServiceVwProdCatSup : 
        EntityRepo<VwProdCatSup>, IDalVwProdCatSup
{
    public IServiceVwProdCatSup(NorthwindContext context)
        : base(context) { }
}