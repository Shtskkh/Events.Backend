using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Repositories;

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
}