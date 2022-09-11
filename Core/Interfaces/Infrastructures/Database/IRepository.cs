using System.Linq.Expressions;
using Domain;

namespace Core;

 public interface IRepository<TEntity> : IBaseEntity
{
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveAsync(Guid id);
    Task RemoveRangeAsync(IEnumerable<Guid> ids);
    Task CommitAsync();
}