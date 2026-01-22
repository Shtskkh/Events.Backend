namespace Events.Domain.Aggregates.EventAggregate.Repositories;

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