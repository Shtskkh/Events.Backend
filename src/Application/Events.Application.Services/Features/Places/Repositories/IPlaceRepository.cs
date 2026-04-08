using Ardalis.Specification;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Places.Repositories;

/// <summary>
///     Репозиторий помещений.
/// </summary>
public interface IPlaceRepository
{
    /// <summary>
    ///     Получить помещение по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность помещения.</returns>
    Task<Place> GetById(int id, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить помещение по спецификации.
    /// </summary>
    /// <param name="spec">Спецификация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Помещение.</returns>
    Task<Place> GetAsync(Specification<Place> spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить помещения по фильтру.
    /// </summary>
    /// <param name="spec">Спецификация фильтра.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция помещений.</returns>
    Task<IReadOnlyCollection<Place>> GetByFilterAsync(Specification<Place> spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить помещение.
    /// </summary>
    /// <param name="place">Помещение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(Place place, CancellationToken cancellationToken);
}