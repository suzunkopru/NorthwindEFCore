using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalRegion : EntityRepo<Region>, IDalRegion
{
    public DalRegion(NorthwindContext context)
                            : base(context) { }
}