using AutoMapper;
using Events.Application.Services.Features.Locations.Specifications;
using Events.Application.Services.Shared;
using Events.Contracts.Locations;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetById;

/// <inheritdoc />
public sealed class GetLocationByIdHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationByIdQuery, LocationDto>
{
    /// <inheritdoc />
    public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new LocationSpec().WithId(request.Id).IncludePhotos().AsNoTracking();
        var location = await locationRepository.FirstOrDefaultAsync(spec, cancellationToken);

        return mapper.Map<LocationDto>(location);
    }
}