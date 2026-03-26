using Ardalis.Specification;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Базовая спецификация для локаций. Содержит методы для подключения связанных сущностей
///     и управления поведением трекинга EF Core.
/// </summary>
public abstract class BaseLocationSpec : Specification<Location>
{
    /// <summary>
    ///     Подключить помещения локации.
    /// </summary>
    public BaseLocationSpec WithPlaces()
    {
        Query.Include(l => l.Places);
        return this;
    }

    /// <summary>
    ///     Подключить фотографии локации.
    /// </summary>
    public BaseLocationSpec WithPhotos()
    {
        Query.Include(l => l.Photos);
        return this;
    }

    /// <summary>
    ///     Отключить трекинг EF Core (оптимизация для read-only запросов).
    /// </summary>
    public new BaseLocationSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}