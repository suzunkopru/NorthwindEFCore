using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceOrder : Service<Order>, IServiceOrder
{
    public ServiceOrder(NorthwindContext context)
                            : base(context) { }
}