using Ardalis.Specification;

namespace Events.Application.Services.Features.Places.Specifications;

public class PlaceByIdSpec : BasePlaceSpec
{
    public PlaceByIdSpec(int id)
    {
        Query.Where(place => place.Id == id);
    }
}