using Ardalis.Specification;
using Events.Domain.Aggregates.LocationAggregate;

namespace Events.Application.Services.Features.Places.Specifications;

/// <summary>
///     Базовая спефикация для помещений.
/// </summary>
public class PlaceSpec : Specification<Place>
{
    public PlaceSpec WithId(int id)
    {
        Query.Where(l => l.Id == id);
        return this;
    }

    public PlaceSpec IncludePhotos()
    {
        Query.Include(l => l.Photos);
        return this;
    }

    public new PlaceSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}