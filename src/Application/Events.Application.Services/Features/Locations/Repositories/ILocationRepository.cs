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
    /// <returns>Коллекция локаций.</returns>
    Task<IReadOnlyCollection<Location>> GetAllAsync();
}