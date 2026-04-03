using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaceById;

/// <inheritdoc />
public class GetPlaceByIdHandler(IPlaceRepository placeRepository, IMapper mapper)
    : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    /// <inheritdoc />
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new PlaceByIdSpec(request.PlaceId).AsNoTracking();
        var places = placeRepository.GetAsync(spec, cancellationToken);

        return mapper.Map<PlaceDto>(places);
    }
}