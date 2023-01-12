using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceCustomer : Service<Customer>, IServiceCustomer
{
    public ServiceCustomer(NorthwindContext context)
                            : base(context) { }
}