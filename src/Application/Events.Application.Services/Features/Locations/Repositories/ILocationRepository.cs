using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Repositories;

/// <summary>
///     Репозиторий локаций.
/// </summary>
public interface ILocationRepository
{
    /// <summary>
    ///     Получить все локации.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция локаций.</returns>
    Task<IReadOnlyCollection<Location>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Получить локацию по ID.
    /// </summary>
    /// <param name="id">Идентификатор локации.</param>
    /// <param name="includePlaces">Добавлять ли </param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект локации.</returns>
    Task<Location> GetByIdAsync(int id, bool includePlaces, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить все помещения локации.
    /// </summary>
    /// <param name="id">Идентификатор локации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция помещений.</returns>
    Task<IReadOnlyCollection<Place>> GetAllPlacesAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    ///     Получить помещение по ID.
    /// </summary>
    /// <param name="locationId">Идентификатор локации.</param>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект помещения.</returns>
    Task<Place> GetPlaceByIdAsync(int locationId, int placeId, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить локацию.
    /// </summary>
    /// <param name="location">Обновлённый объект локации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(Location location, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавить локацию.
    /// </summary>
    /// <param name="location">Локация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID добавленной локации.</returns>
    Task<int> AddAsync(Location location, CancellationToken cancellationToken);
}