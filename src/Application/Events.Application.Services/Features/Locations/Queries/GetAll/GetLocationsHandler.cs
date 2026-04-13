using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Locations;
using Events.Domain.Aggregates.LocationAggregate;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAll;

/// <summary>
///     Handler для получения локаций.
/// </summary>
/// <param name="locationRepository">Репозиторий локаций.</param>
/// <param name="mapper">Маппер.</param>
public sealed class GetLocationsHandler(IRepository<Location> locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationsQuery, IReadOnlyCollection<ShortLocationDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortLocationDto>> Handle(GetLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var locations = await locationRepository.ListAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<ShortLocationDto>>(locations);
    }
}