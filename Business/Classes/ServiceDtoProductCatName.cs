﻿using Business.Interfaces;
using Core.DTOs;
using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Business.Classes;
public class ServiceDtoProductCatName
            : Service<Product>, IServiceDtoProductCatName
{
    public ServiceDtoProductCatName(IEntityRepo<Product> entityRepo) 
        : base(entityRepo) { }
    private readonly NorthwindContext context= new();
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