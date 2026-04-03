using Events.Application.Services.Features.Locations.Specifications;
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
    ///     Получить локацию по спецификации.
    /// </summary>
    /// <param name="spec">Спецификация запроса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект локации.</returns>
    Task<Location> GetAsync(BaseLocationSpec spec, CancellationToken cancellationToken);

    /// <summary>
    ///     Добавить локацию.
    /// </summary>
    /// <param name="location">Локация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>ID добавленной локации.</returns>
    Task AddAsync(Location location, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновить локацию.
    /// </summary>
    /// <param name="location">Обновлённый объект локации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task UpdateAsync(Location location, CancellationToken cancellationToken);

    /// <summary>
    ///     Удалить локацию.
    /// </summary>
    /// <param name="location">Локация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Location location, CancellationToken cancellationToken);
}