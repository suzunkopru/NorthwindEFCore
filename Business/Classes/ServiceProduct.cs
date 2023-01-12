using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceProduct : Service<Product>, IServiceProduct
{
    public ServiceProduct(NorthwindContext context)
                            : base(context) { }
}