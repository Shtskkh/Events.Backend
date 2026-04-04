using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAll;

/// <summary>
///     Handler для получения локаций.
/// </summary>
/// <param name="locationRepository">Репозиторий локаций.</param>
/// <param name="mapper">Маппер.</param>
public class GetLocationsHandler(ILocationRepository locationRepository, IMapper mapper)
    : IRequestHandler<GetLocationsQuery, IReadOnlyCollection<ShortLocationDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortLocationDto>> Handle(GetLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var locations = await locationRepository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<ShortLocationDto>>(locations);
    }
}