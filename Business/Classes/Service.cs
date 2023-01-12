using DataAccess.Interfaces;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Core.Helper;
using Core.UnitOfWork;
namespace DataAccess.Classes;
public class Service<T> : IService<T>
    where T : class, new()
{
    private readonly NorthwindContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly IUnitOfWork _unitOfWork;
    private NorthwindContext context;
    public Service(NorthwindContext context)
    {
        TranLevel.TranWithNoLock();
        _unitOfWork = new UnitOfWork(context);
        _dbSet = (_context = context).Set<T>();
    }

    public IQueryable<T> GetAll()
        => _dbSet.AsNoTracking();
    public IQueryable<T> Where
        (Expression<Func<T, bool>> predicate)
        => _dbSet.AsNoTracking().Where(predicate);
    public async Task<T> GetByIdAsync(int id)
        => (await _dbSet.FindAsync(id).ConfigureAwait(false))!;
    public async Task<bool> AnyAsync
        (Expression<Func<T, bool>> predicate)
        => await _dbSet.AnyAsync(predicate).ConfigureAwait(false);
    private async Task CUD(T entity, EntityState state)
    {
        _context.Entry(entity).State = state;
        await _unitOfWork.CommitAsync().ConfigureAwait(false);
        //await _context.SaveChangesAsync();
        _context.Entry(entity).State = EntityState.Detached;
    }
    public async Task AddAsync(T entity)
        => await CUD(entity, EntityState.Added)
                                        .ConfigureAwait(false);
    public async Task AddRangeAsync(IQueryable<T> entities)
    {
        foreach (var x in entities) await AddAsync(x)
                                .ConfigureAwait(false);
    }
    public void Update(T entity)
        => Task.FromResult(CUD(entity, EntityState.Modified));
    public void RemoveRange(IQueryable<T> entities)
        => entities.ToList().ForEach(Remove);
    public void Remove(T entity)
    {
        try
        {
            Task.FromResult(CUD(entity, EntityState.Deleted));
        }
        catch (DbUpdateException ex)
        {
            throw new Exception($@"İlişkili bir kayıt var. 
                            Veriyi silemezsiniz. {ex.Message}");
        }
    }
}
public enum CUDType
{
    Insert, Update, Delete
}