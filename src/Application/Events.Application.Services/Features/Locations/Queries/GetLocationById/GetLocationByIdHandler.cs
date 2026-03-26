using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
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
        var spec = new LocationByIdSpec(request.Id).WithPhotos().AsNoTracking();
        var location = await locationRepository.GetAsync(spec, cancellationToken);

        return mapper.Map<LocationDto>(location);
    }
}