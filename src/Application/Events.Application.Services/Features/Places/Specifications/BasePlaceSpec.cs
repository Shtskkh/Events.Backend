using Ardalis.Specification;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Places.Specifications;

/// <summary>
///     Базовая спефикация для помещений.
/// </summary>
public abstract class BasePlaceSpec : Specification<Place>
{
    /// <summary>
    ///     Подключить фотографии локации.
    /// </summary>
    public BasePlaceSpec IncludePhotos()
    {
        Query.Include(l => l.Photos);
        return this;
    }

    /// <summary>
    ///     Отключить трекинг EF Core (оптимизация для read-only запросов).
    /// </summary>
    public new BasePlaceSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}