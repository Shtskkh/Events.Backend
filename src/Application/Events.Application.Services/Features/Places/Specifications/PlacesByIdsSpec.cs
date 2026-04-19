using Ardalis.Specification;
using Events.Domain.Aggregates.Locations;

namespace Events.Application.Services.Features.Places.Specifications;

public class PlacesByIdsSpec : Specification<Place>
{
    public PlacesByIdsSpec(IEnumerable<int> placesIds)
    {
        Query.Where(p => placesIds.Contains(p.Id));
    }

    public new PlacesByIdsSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}