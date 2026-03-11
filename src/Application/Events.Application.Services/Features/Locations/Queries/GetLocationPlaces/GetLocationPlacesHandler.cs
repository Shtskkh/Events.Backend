using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Features.Locations.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetLocationPlaces;

/// <inheritdoc />
public class GetLocationPlacesHandler(ILocationRepository locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationPlacesQuery, IReadOnlyCollection<ShortPlaceDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortPlaceDto>> Handle(GetLocationPlacesQuery request,
        CancellationToken cancellationToken)
    {
        var places = await locationRepository.GetAllPlacesAsync(request.Id, cancellationToken);

        return mapper.Map<IReadOnlyCollection<ShortPlaceDto>>(places);
    }
}