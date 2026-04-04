using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Places.Repositories;

/// <summary>
///     Репозиторий типов помещений.
/// </summary>
public interface IPlaceTypeRepository
{
    /// <summary>
    ///     Получить все типы помещений.
    /// </summary>
    /// <returns>Коллекция типов помещений.</returns>
    Task<IReadOnlyCollection<PlaceType>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Получить тип помещения по ID.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объект типа помещения.</returns>
    Task<PlaceType> GetByIdAsync(int id, CancellationToken cancellationToken);
}