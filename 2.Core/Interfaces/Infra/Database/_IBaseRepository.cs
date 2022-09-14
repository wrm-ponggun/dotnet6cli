using System.Linq.Expressions;
using Domain;

namespace Core;

public interface IBaseRepository<TEntity> where TEntity:IBaseEntity
{
    Task<TEntity> GetByIdAsync(Guid id);
    List<TEntity> GetByConditions(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(List<TEntity> entities);
    Task SaveChangesAsync();
}