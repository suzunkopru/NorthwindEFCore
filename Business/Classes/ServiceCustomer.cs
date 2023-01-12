using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceCustomer : Service<Customer>, IServiceCustomer
{
    public ServiceCustomer(NorthwindContext context)
                            : base(context) { }
}