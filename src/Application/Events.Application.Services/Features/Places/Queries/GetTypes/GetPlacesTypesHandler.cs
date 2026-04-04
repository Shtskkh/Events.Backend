using AutoMapper;
using Events.Application.Services.Features.Places.Repositories;
using Events.Contracts.Places.PlacesTypes;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetTypes;

/// <summary>
///     Handler для получения всех типов помещений.
/// </summary>
/// <param name="repository">Репозиторий типов помещений.</param>
/// <param name="mapper">Маппер.</param>
public class GetPlacesTypesHandler(IPlaceTypeRepository repository, IMapper mapper)
    : IRequestHandler<GetPlacesTypesQuery, IReadOnlyCollection<PlaceTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceTypeDto>> Handle(GetPlacesTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await repository.GetAllAsync(cancellationToken);

        return mapper.Map<IReadOnlyCollection<PlaceTypeDto>>(types);
    }
}