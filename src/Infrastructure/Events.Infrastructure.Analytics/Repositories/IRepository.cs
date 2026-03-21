using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Analytics.Repositories;

/// <summary>
///     Generic репозиторий для работы с сущностями.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TContext">Тип контекста базы данных.</typeparam>
public interface IRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
{
    /// <summary>
    ///     Метод получения всех сущностей репозитория.
    /// </summary>
    /// <returns> DbSet сущности.</returns>
    IQueryable<TEntity> GetAllAsync();

    /// <summary>
    ///     Метод асинхронного добавления сущности.
    /// </summary>
    /// <param name="entity">Объект сущности для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}