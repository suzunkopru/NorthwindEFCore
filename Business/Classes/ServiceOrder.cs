using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceOrder : Service<Order>, IServiceOrder
{
    public ServiceOrder(NorthwindContext context)
                            : base(context) { }
}