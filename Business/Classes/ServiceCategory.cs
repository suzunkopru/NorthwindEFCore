using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceCategory 
    : Service<Category>, IServiceCategory
{
    public ServiceCategory
        (IEntityRepo<Category> entityRepo)
                        : base(entityRepo) { }
}