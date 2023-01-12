using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class ServiceCategory : Service<Category>, IServiceCategory
{
    public ServiceCategory(NorthwindContext context)
                            : base(context) { }
}