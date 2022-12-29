using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalVwProdCatSup : 
        EntityRepo<VwProdCatSup>, IDalVwProdCatSup
{
    public DalVwProdCatSup(NorthwindContext context)
        : base(context) { }
}