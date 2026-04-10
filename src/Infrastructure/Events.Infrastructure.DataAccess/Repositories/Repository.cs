using Events.Application.Services.Shared;
using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Repositories;

/// <inheritdoc />
public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
    where TContext : DbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    ///     Конструктор репозитория.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public Repository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TResult>> QueryAsync<TResult>(QueryObject<TEntity, TResult> queryObject,
        CancellationToken cancellationToken)
    {
        var baseQuery = _dbSet.AsNoTracking();
        return await queryObject(baseQuery).ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> IsExistsAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(e => e.Id.Equals(id), cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}