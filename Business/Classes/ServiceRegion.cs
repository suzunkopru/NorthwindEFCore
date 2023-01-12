using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceRegion : Service<Region>, IServiceRegion
{
    public ServiceRegion(NorthwindContext context)
                            : base(context) { }
}