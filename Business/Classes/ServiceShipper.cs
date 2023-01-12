using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceShipper : Service<Shipper>, IServiceShipper
{
    public ServiceShipper(NorthwindContext context)
                            : base(context) { }
}