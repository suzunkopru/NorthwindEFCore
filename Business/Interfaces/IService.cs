﻿using System.Linq.Expressions;
namespace Business.Interfaces;
public interface IService<T>
    where T : class, new()
{
    IQueryable<T> GetAll();
    IQueryable<T> Where
        (Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int id);
    Task<bool>
     AnyAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IQueryable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IQueryable<T> entities);
}