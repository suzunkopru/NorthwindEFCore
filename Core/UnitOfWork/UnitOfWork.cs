using Entities.Context;
using Microsoft.EntityFrameworkCore.Storage;
namespace Core.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly NorthwindContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(NorthwindContext context)
                        => _context = context;
    public void Commit()
    {
        using (_transaction =
                   _context.Database.BeginTransaction())
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                throw new Exception($"{e.Message}");
            }
        }
    }
    public async Task CommitAsync()
    {
        await using (_transaction = await
                   _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await _transaction.RollbackAsync();
                throw new Exception($"{e.Message}");
            }
        }
    }
}