using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Repositories;

public interface IRepository<TEntity, in TKey, TContext>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
    where TContext : DbContext
{
    IQueryable<TEntity> GetAllAsync();
    Task<TEntity> GetByIdAsync(TKey id);
    Task<bool> IsExistsAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
}