using AutoMapper;
using Events.Application.Services.Features.Locations.Repositories;
using Events.Contracts.Places.PlacesTypes;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAllPlacesTypes;

/// <summary>
///     Handler для получения всех типов помещений.
/// </summary>
/// <param name="repository">Репозиторий типов помещений.</param>
/// <param name="mapper">Маппер.</param>
public class GetAllPlacesTypesHandler(IPlaceTypeRepository repository, IMapper mapper)
    : IRequestHandler<GetAllPlacesTypesQuery, IReadOnlyCollection<PlaceTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceTypeDto>> Handle(GetAllPlacesTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<PlaceTypeDto>>(types);
    }
}