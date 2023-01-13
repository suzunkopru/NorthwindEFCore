using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;
namespace Core.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly NorthwindContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(NorthwindContext context)
                        => _context = context;
    public void Commit() => WithTransaction(false);
    public Task CommitAsync()
    {
        WithTransaction();
        return Task.CompletedTask;
    }
    private void WithTransaction(bool isAsync = true)
    {
        using (_transaction =
               _context.Database.BeginTransaction
                   (IsolationLevel.ReadUncommitted))
            try
            {
                if (isAsync)
                {
                    _context.SaveChangesAsync();
                    _transaction.CommitAsync();
                }
                else
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                }
            }
            catch (TransactionException e)
            {
                _transaction.RollbackAsync();
                throw new Exception($"{e.Message}");
            }
    }
}