using DataAccess.Interfaces;
using Entities.Context;
using Entities.DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Classes;
public class DalDtoProductCatName
            : EntityRepo<Product>, IDalDtoProductCatName
{
    private readonly NorthwindContext context= new();
    public DalDtoProductCatName(NorthwindContext context)
        : base(context) {}
    public IQueryable<DtoProductCatName> GetProductsCatName()
        => context.Products.AsQueryable().Join(context.Categories,
            pr => pr.CategoryId,
            ct => ct.CategoryId,
            (pr, ct) =>
                new DtoProductCatName
                {
                    ProductID = pr.ProductId,
                    ProductName = pr.ProductName,
                    CategoryName = ct.CategoryName,
                    UnitsInStock = (short)pr.UnitsInStock
                });
    public IQueryable<DtoProductCatName> GetProductsCatName
        (DbSet<Product> produts, DbSet<Category> categoriest)
        => from P in produts
            join C in categoriest
                on P.CategoryId equals C.CategoryId
            select new DtoProductCatName
            {
                ProductID = P.ProductId,
                ProductName = P.ProductName,
                CategoryName = C.CategoryName,
                UnitsInStock = (short)P.UnitsInStock
            };
    public IQueryable<Product> GetProductsByCatergory
        (int catID) => Where(x => x.CategoryId == catID);
}