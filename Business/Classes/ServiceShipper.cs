using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceShipper : Service<Shipper>, IServiceShipper
{
    public ServiceShipper(NorthwindContext context)
                            : base(context) { }
}