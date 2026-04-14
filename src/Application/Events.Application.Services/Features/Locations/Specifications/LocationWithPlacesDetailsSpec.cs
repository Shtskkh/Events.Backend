using Ardalis.Specification;
using Events.Domain.Aggregates.Locations;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Спецификация загрузки локации с деталями помещений.
/// </summary>
public class LocationWithPlacesDetailsSpec : Specification<Location>
{
    public LocationWithPlacesDetailsSpec(int locationId)
    {
        Query.Where(p => p.Id == locationId);

        Query.Include(l => l.Places).ThenInclude(p => p.Photos);

        Query.AsNoTracking();
    }
}