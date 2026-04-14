using Ardalis.Specification;
using Events.Domain.Aggregates.Locations;

namespace Events.Application.Services.Features.Locations.Specifications;

public class LocationByIdSpec : Specification<Location>
{
    public LocationByIdSpec(int locationId)
    {
        Query.Where(l => l.Id == locationId);
    }

    public new LocationByIdSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }

    public LocationByIdSpec IncludePlaces()
    {
        Query.Include(l => l.Places);
        return this;
    }
}