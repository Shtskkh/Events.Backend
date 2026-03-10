using Events.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess.Repositories;

/// <summary>
///     Generic репозиторий для работы с сущностями.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <typeparam name="TKey">Тип ключа сущности.</typeparam>
/// <typeparam name="TContext">Тип контекста базы данных.</typeparam>
public interface IRepository<TEntity, in TKey, TContext>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
    where TContext : DbContext
{
    /// <summary>
    ///     Метод получения всех сущностей репозитория.
    /// </summary>
    /// <returns>
    ///     DbSet сущности.
    /// </returns>
    IQueryable<TEntity> GetAllAsync();

    /// <summary>
    ///     Метод асинхронного получения сущности по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>
    ///     Объект сущностью
    /// </returns>
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

    /// <summary>
    ///     Метод асинхронной проверки существования сущности.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>
    ///     True, если сущность существует, false иначе.
    /// </returns>
    Task<bool> IsExistsAsync(TKey id, CancellationToken cancellationToken);

    /// <summary>
    ///     Метод асинхронного добавления сущности.
    /// </summary>
    /// <param name="entity">Объект сущности для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    ///     Метод асинхронного обновления сущности.
    /// </summary>
    /// <param name="entity">Объект сущности для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);


    /// <summary>
    ///     Метод асинхронного удаления сущности.
    /// </summary>
    /// <param name="entity">Объект сущности для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}