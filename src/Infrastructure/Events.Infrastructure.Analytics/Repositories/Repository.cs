using ClickHouse.Driver;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Analytics.Repositories;

/// <inheritdoc />
public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
{
    private readonly ClickHouseClient _clickHouseClient;
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    ///     Конструктор репозитория.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    /// <param name="clickHouseClient">Клиент для операций вставки.</param>
    public Repository(TContext context, ClickHouseClient clickHouseClient)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
        _clickHouseClient = clickHouseClient;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet;
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var tableName = _context.Model
            .FindEntityType(typeof(TEntity))!
            .GetTableName()!;

        var columns = _context.Model
            .FindEntityType(typeof(TEntity))!
            .GetProperties()
            .Select(p => p.GetColumnName())
            .ToArray();

        var values = columns
            .Select(col => _context.Model
                .FindEntityType(typeof(TEntity))!
                .GetProperties()
                .First(p => p.GetColumnName() == col)
                .PropertyInfo!
                .GetValue(entity)!)
            .ToArray();

        await _clickHouseClient.InsertBinaryAsync(
            tableName,
            columns,
            [values],
            cancellationToken: cancellationToken
        );
    }
}