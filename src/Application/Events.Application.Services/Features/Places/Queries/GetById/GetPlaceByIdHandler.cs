using AutoMapper;
using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetById;

/// <inheritdoc />
public sealed class GetPlaceByIdHandler(IRepository<Place> placeRepository, IMapper mapper)
    : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    /// <inheritdoc />
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var placeByIdSpec = new PlaceByIdSpec(request.PlaceId).IncludePhotos().AsNoTracking();
        var place = await placeRepository.FirstOrDefaultAsync(placeByIdSpec, cancellationToken);

        return mapper.Map<PlaceDto>(place);
    }
}