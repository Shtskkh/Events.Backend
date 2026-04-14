using AutoMapper;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaces;

public sealed class GetLocationPlacesHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationPlacesQuery, IReadOnlyCollection<ShortPlaceDto>>
{
    public async Task<IReadOnlyCollection<ShortPlaceDto>> Handle(GetLocationPlacesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new LocationWithPlacesDetailsSpec(request.LocationId).AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (location == null)
            throw new NotFoundException(LocationErrorMessages.NotFoundById(request.LocationId));

        return mapper.Map<IReadOnlyCollection<ShortPlaceDto>>(location.Places);
    }
}