using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceEmployee : Service<Employee>, IServiceEmployee
{
    public ServiceEmployee(NorthwindContext context)
                            : base(context) { }
}