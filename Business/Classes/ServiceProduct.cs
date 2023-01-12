using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceProduct : Service<Product>, IServiceProduct
{
    public ServiceProduct(NorthwindContext context)
                            : base(context) { }
}