using Ardalis.Specification;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Спецификация загрузки страницы 
/// </summary>
public class LocationWithPlacesDetailsSpec : BaseLocationSpec
{
    public LocationWithPlacesDetailsSpec(int id)
    {
        Query.Where(l => l.Id == id);

        Query.Include(l => l.Places)
            .ThenInclude(p => p.Photos);
    }
}