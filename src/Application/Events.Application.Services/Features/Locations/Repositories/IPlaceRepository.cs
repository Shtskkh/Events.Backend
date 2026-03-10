using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Repositories;

/// <summary>
///     Репозиторий помещений.
/// </summary>
public interface IPlaceRepository
{
    /// <summary>
    ///     Добавить помещение.
    /// </summary>
    /// <param name="place">Объект помещения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID добавленного помещения.</returns>
    Task<int> AddPlaceAsync(Place place, CancellationToken cancellationToken);
}