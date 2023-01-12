using Entities.Context;
using System.Transactions;
using static Core.Helper.TranLevel;
namespace Core.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly NorthwindContext _context;
    private TransactionScope _transaction;
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
        using (_transaction = TranWithNoLock())
            try
            {
                if (!isAsync) _context.SaveChanges();
                else _context.SaveChangesAsync();
                _transaction.Complete();
            }
            catch (TransactionAbortedException e)
            {
                _transaction.Dispose();
                throw new Exception($"{e.Message}");
            }
    }
}