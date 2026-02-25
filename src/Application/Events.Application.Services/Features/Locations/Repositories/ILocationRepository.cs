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

    /// <summary>
    ///     Получить локацию по ID.
    /// </summary>
    /// <param name="id">Идентификатор локации.</param>
    /// <returns>Объект локации.</returns>
    Task<Location> GetByIdAsync(int id);

    /// <summary>
    ///     Обновить локацию.
    /// </summary>
    /// <param name="location">Обновлённый объект локации.</param>
    Task UpdateAsync(Location location);

    /// <summary>
    ///     Добавить локацию.
    /// </summary>
    /// <param name="location">Локация.</param>
    /// <returns>ID добавленной локации.</returns>
    Task<int> AddAsync(Location location);
}