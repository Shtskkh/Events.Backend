using AutoMapper;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Places;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetPlaces;

/// <inheritdoc />
public sealed class GetLocationPlacesHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationPlacesQuery, IReadOnlyCollection<ShortPlaceDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortPlaceDto>> Handle(GetLocationPlacesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new LocationWithPlacesDetailsSpec(request.Id).AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

        return mapper.Map<IReadOnlyCollection<ShortPlaceDto>>(location.Places);
    }
}