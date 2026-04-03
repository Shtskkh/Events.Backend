using Ardalis.Specification;

namespace Events.Application.Services.Features.Locations.Specifications;

public class PlaceByIdSpec : BasePlaceSpec
{
    public PlaceByIdSpec(int id)
    {
        Query.Where(place => place.Id == id);
    }
}