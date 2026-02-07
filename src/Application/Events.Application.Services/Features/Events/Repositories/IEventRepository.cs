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
    /// <returns>
    ///     Сущность мероприятия.
    /// </returns>
    Task<Event> GetByIdAsync(Guid id);

    /// <summary>
    ///     Получить мероприятия, удовлетворяющие фильтру.
    /// </summary>
    /// <param name="spec">Спецификация фильтра.</param>
    /// <returns>Иммутабельная коллекция мероприятий.</returns>
    Task<IReadOnlyCollection<Event>> GetByFilterAsync(Specification<Event> spec);

    /// <summary>
    ///     Добавить мероприятие.
    /// </summary>
    /// <param name="event">Объект мероприятия.</param>
    Task AddAsync(Event @event);
}