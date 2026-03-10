using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Repositories;

/// <summary>
///     Репозиторий форматов мероприятий.
/// </summary>
public interface IEventFormatRepository
{
    /// <summary>
    ///     Получить формат мероприятия по ID.
    /// </summary>
    /// <param name="id">Идентификатор формата мероприятия.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность формата мероприятия.</returns>
    Task<EventFormat> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить все форматы мероприятий.
    /// </summary>
    /// <returns>Коллекция форматов мероприятий.</returns>
    Task<IReadOnlyCollection<EventFormat>> GetAllAsync(CancellationToken cancellationToken);
}