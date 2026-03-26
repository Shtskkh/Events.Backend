using Ardalis.Specification;

namespace Events.Application.Services.Features.Locations.Specifications;

/// <summary>
///     Спецификация получения локации по ID.
/// </summary>
public class LocationByIdSpec : BaseLocationSpec
{
    public LocationByIdSpec(int id)
    {
        Query.Where(l => l.Id == id);
    }
}