using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalCustomer : EntityRepo<Customer>, IDalCustomer
{
    public DalCustomer(NorthwindContext context)
                            : base(context) { }
}