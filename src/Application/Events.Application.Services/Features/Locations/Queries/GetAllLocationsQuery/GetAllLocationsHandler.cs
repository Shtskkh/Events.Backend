using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Features.Locations.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAllLocationsQuery;

/// <summary>
///     Handler для получения локаций.
/// </summary>
/// <param name="locationRepository">Репозиторий локаций.</param>
/// <param name="mapper">Маппер.</param>
public class GetAllLocationsHandler(ILocationRepository locationRepository, IMapper mapper)
    : IRequestHandler<GetAllLocationsQuery, IReadOnlyCollection<ShortLocationDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortLocationDto>> Handle(GetAllLocationsQuery request,
        CancellationToken cancellationToken)
    {
        var locations = await locationRepository.GetAllAsync();

        return mapper.Map<IReadOnlyCollection<ShortLocationDto>>(locations);
    }
}