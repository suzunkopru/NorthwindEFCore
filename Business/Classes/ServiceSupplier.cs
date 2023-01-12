using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceSupplier 
    : Service<Supplier>, IServiceSupplier
{
    public ServiceSupplier
        (IEntityRepo<Supplier> entityRepo) 
                        : base(entityRepo) { }
}