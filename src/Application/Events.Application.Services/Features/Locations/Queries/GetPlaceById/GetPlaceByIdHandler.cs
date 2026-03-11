using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Features.Locations.Places;
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
        var location =
            await locationRepository.GetPlaceByIdAsync(request.LocationId, request.PlaceId, cancellationToken);

        return mapper.Map<PlaceDto>(location);
    }
}