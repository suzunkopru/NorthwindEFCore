using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceVwProdCatSup : 
        Service<VwProdCatSup>, IServiceVwProdCatSup
{
    public ServiceVwProdCatSup(NorthwindContext context)
        : base(context) { }
}