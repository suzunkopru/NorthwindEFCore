using Business.Interfaces;
using Entities.Context;
using Entities.Models;
namespace Business.Classes;
public class ServiceCategory : Service<Category>, IServiceCategory
{
    public ServiceCategory(NorthwindContext context)
                            : base(context) { }
}