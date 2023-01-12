using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceEmployee : Service<Employee>, IServiceEmployee
{
    public ServiceEmployee(NorthwindContext context)
                            : base(context) { }
}