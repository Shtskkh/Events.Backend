using AutoMapper;
using Events.Application.Services.Features.Places.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetById;

/// <inheritdoc />
public sealed class GetPlaceByIdHandler(IRepository<Place> placeRepository, IMapper mapper)
    : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    /// <inheritdoc />
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new PlaceSpec().WithId(request.PlaceId).IncludePhotos().AsNoTracking();
        var places = await placeRepository.FirstOrDefaultAsync(spec, cancellationToken);

        return mapper.Map<PlaceDto>(places);
    }
}