using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalSupplier : EntityRepo<Supplier>, IDalSupplier
{
    public DalSupplier(NorthwindContext context)
                            : base(context) { }
}