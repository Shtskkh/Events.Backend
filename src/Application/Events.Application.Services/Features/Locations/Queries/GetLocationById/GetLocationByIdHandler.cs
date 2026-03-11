using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Features.Locations.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetLocationById;

/// <inheritdoc />
public class GetLocationByIdHandler(ILocationRepository locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationByIdQuery, LocationDto>
{
    /// <inheritdoc />
    public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        const bool includePlaces = false;

        var location = await locationRepository.GetByIdAsync(request.Id, includePlaces, cancellationToken);

        return mapper.Map<LocationDto>(location);
    }
}