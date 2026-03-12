using Ardalis.Specification;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Repositories;

/// <summary>
///     Репозиторий мероприятий.
/// </summary>
public interface IEventRepository
{
    /// <summary>
    ///     Получить мероприятие по ID.
    /// </summary>
    /// <param name="id">ID мероприятия.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>
    ///     Сущность мероприятия.
    /// </returns>
    Task<Event> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить мероприятия, удовлетворяющие фильтру.
    /// </summary>
    /// <param name="spec">Спецификация фильтра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <param name="textQuery">Запрос текстового поиска.</param>
    /// <returns>Коллекция мероприятий.</returns>
    Task<IReadOnlyCollection<Event>> GetByFilterAsync(
        Specification<Event> spec,
        CancellationToken cancellationToken,
        string? textQuery = null
    );

    /// <summary>
    ///     Добавить мероприятие.
    /// </summary>
    /// <param name="event">Объект мероприятия.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task AddAsync(Event @event, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить мероприятие.
    /// </summary>
    /// <param name="event">Мероприятие для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(Event @event, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить мероприятие.
    /// </summary>
    /// <param name="event">Сущность мероприятия для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Event @event, CancellationToken cancellationToken);
}