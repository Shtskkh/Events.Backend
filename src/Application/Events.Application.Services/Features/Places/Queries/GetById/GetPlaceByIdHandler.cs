using AutoMapper;
using Events.Application.Services.Features.Places.Repositories;
using Events.Application.Services.Features.Places.Specifications;
using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetById;

/// <inheritdoc />
public sealed class GetPlaceByIdHandler(IPlaceRepository placeRepository, IMapper mapper)
    : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    /// <inheritdoc />
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new PlaceSpec().WithId(request.PlaceId).AsNoTracking();
        var places = await placeRepository.GetAsync(spec, cancellationToken);

        return mapper.Map<PlaceDto>(places);
    }
}