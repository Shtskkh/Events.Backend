using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaceById;

/// <inheritdoc />
public class GetPlaceByIdHandler(ILocationRepository locationRepository, IMapper mapper)
    : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    /// <inheritdoc />
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        const bool includeLocations = true;
        var location = await locationRepository.GetByIdAsync(request.LocationId, includeLocations, cancellationToken);
        var places = location.FindPlace(request.PlaceId);

        return mapper.Map<PlaceDto>(places);
    }
}