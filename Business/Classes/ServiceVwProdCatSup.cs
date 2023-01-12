using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceVwProdCatSup : 
        Service<VwProdCatSup>, IServiceVwProdCatSup
{
    public ServiceVwProdCatSup(NorthwindContext context)
        : base(context) { }
}