using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceTerritory : Service<Territory>, IServiceTerritory
{
    public ServiceTerritory(NorthwindContext context)
                            : base(context) { }
}