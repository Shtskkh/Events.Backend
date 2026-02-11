using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Repositories;

/// <summary>
///     Репозиторий типов мероприятий.
/// </summary>
public interface IEventTypeRepository
{
    /// <summary>
    ///     Получить тип мероприятия по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>
    ///     Сущность типа мероприятия.
    /// </returns>
    Task<EventType> GetById(int id);

    /// <summary>
    ///     Получить все типы мероприятий.
    /// </summary>
    /// <returns>
    ///     Коллекцию типов мероприятий.
    /// </returns>
    Task<IReadOnlyCollection<EventType>> GetAllAsync();
}