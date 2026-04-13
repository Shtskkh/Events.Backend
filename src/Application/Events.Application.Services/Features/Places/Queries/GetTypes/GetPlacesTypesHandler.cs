using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Places.PlacesTypes;
using Events.Domain.Aggregates.Locations;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetTypes;

/// <summary>
///     Handler для получения всех типов помещений.
/// </summary>
/// <param name="placeTypeRepository">Репозиторий типов помещений.</param>
/// <param name="mapper">Маппер.</param>
public sealed class GetPlacesTypesHandler(IRepository<PlaceType> placeTypeRepository, IMapper mapper)
    : IRequestHandler<GetPlacesTypesQuery, IReadOnlyCollection<PlaceTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceTypeDto>> Handle(GetPlacesTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await placeTypeRepository.ListAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<PlaceTypeDto>>(types);
    }
}