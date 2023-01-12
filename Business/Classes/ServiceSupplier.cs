using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceSupplier : Service<Supplier>, IServiceSupplier
{
    public ServiceSupplier(NorthwindContext context)
                            : base(context) { }
}