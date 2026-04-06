using Ardalis.Specification;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Спецификация загрузки локации с деталями помещений.
/// </summary>
public class LocationWithPlacesDetailsSpec : LocationSpec
{
    public LocationWithPlacesDetailsSpec(int id)
    {
        WithId(id);
        Query.Include(l => l.Places)
            .ThenInclude(p => p.Photos);
    }
}