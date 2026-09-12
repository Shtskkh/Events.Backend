using Ardalis.Specification;
using Events.Domain.Aggregates.Locations;

namespace Events.Application.Services.Features.Places.Specifications;

public class PlaceByIdSpec : Specification<Place>
{
    public PlaceByIdSpec(int placeId)
    {
        Query.Where(place => place.Id == placeId);
    }

    public PlaceByIdSpec IncludePhotos()
    {
        Query.Include(place => place.Photos);
        return this;
    }

    public new PlaceByIdSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}