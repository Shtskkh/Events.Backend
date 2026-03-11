using Ardalis.Specification;
using Events.Domain.Aggregates.UserAggregate;

namespace Events.Application.Services.Features.Users.Repositories;

/// <summary>
///     Репозиторий пользователей.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///     Получить всех пользователей, удовлетворяющих фильтру.
    /// </summary>
    /// <param name="spec">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекцию пользователей.</returns>
    Task<IReadOnlyCollection<User>> GetByFilterAsync(Specification<User> spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить пользователя по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность пользователя.</returns>
    Task<User> GetById(Guid id, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавить пользователя.
    /// </summary>
    /// <param name="user">Сущность пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID созданного пользователя.</returns>
    Task AddAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить пользователя.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(User user, CancellationToken cancellationToken);
}