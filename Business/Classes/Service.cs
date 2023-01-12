using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DataAccess.Interfaces;
namespace Business.Classes;
public class Service<T> : IService<T>
    where T : class, new()
{
    private readonly IEntityRepo<T> _entityRepo;
    public Service(IEntityRepo<T> entityRepo)
        => _entityRepo = entityRepo;
    public IQueryable<T> GetAll()
        => _entityRepo.GetAll();
    public IQueryable<T> Where
        (Expression<Func<T, bool>> predicate)
        => _entityRepo.Where(predicate);
    public async Task<T> GetByIdAsync(int id)
        => (await _entityRepo.GetByIdAsync(id)
            .ConfigureAwait(false))!;
    public async Task<bool> AnyAsync
        (Expression<Func<T, bool>> predicate)
        => await _entityRepo.AnyAsync(predicate)
            .ConfigureAwait(false);
    public async Task AddAsync(T entity)
        => await _entityRepo.AddAsync(entity)
            .ConfigureAwait(false);
    public async Task AddRangeAsync(IQueryable<T> entities)
    {
        foreach (var x in entities) await AddAsync(x)
            .ConfigureAwait(false);
    }
    public void Update(T entity)
        => _entityRepo.Update(entity);
    public void RemoveRange(IQueryable<T> entities)
        => entities.ToList().ForEach(Remove);
    public void Remove(T entity)
    {
        try
        {
            _entityRepo.Remove(entity);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception($@"İlişkili bir kayıt var. 
                            Veriyi silemezsiniz. {ex.Message}");
        }
    }
}