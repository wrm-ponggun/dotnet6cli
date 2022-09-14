using Domain;
using Core;
using System.Linq.Expressions;

namespace Infra;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
        this._context = context;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public List<TEntity> GetByConditions(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Where(predicate).ToList();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        entity.UpdatedUTC = DateTime.UtcNow;
        entity.IsActive = false;
    }

    public void RemoveRange(List<TEntity> entities)
    {
        entities.ForEach( c=> Remove(c) );
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
