using Ardalis.Specification;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Загружает локацию со всем графом для страницы детального просмотра:
///     Places -> Photos
/// </summary>
public class LocationWithPlacesDetailsSpec : BaseLocationSpec
{
    public LocationWithPlacesDetailsSpec(int id)
    {
        Query.Where(l => l.Id == id);

        Query.Include(l => l.Places).ThenInclude(p => p.Photos);

        Query.AsNoTracking();
    }
}