using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceSupplier : Service<Supplier>, IServiceSupplier
{
    public ServiceSupplier(NorthwindContext context)
                            : base(context) { }
}