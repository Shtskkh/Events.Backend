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
}