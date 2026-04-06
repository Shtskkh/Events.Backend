using Ardalis.Specification;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Базовая спецификация для локаций.
/// </summary>
public class LocationSpec : Specification<Location>
{
    public LocationSpec WithId(int id)
    {
        Query.Where(l => l.Id == id);
        return this;
    }

    public LocationSpec IncludePlaces()
    {
        Query.Include(l => l.Places);
        return this;
    }

    public LocationSpec IncludePhotos()
    {
        Query.Include(l => l.Photos);
        return this;
    }

    public new LocationSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}