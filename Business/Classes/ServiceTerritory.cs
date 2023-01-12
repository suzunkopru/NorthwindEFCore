using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceTerritory : Service<Territory>, IServiceTerritory
{
    public ServiceTerritory(NorthwindContext context)
                            : base(context) { }
}