using AutoMapper;
using Events.Application.Services.Shared;
using Events.Contracts.Places.PlacesTypes;
using Events.Domain.Aggregates.Locations;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetTypes;

public sealed class GetPlacesTypesHandler(IRepository<PlaceType> placeTypeRepository, IMapper mapper)
    : IRequestHandler<GetPlacesTypesQuery, IReadOnlyCollection<PlaceTypeDto>>
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<PlaceTypeDto>> Handle(GetPlacesTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await placeTypeRepository.ListAsync(cancellationToken);

        if (types.Count == 0)
            throw new NotFoundException(PlaceTypeErrors.NotFoundAny);

        return mapper.Map<IReadOnlyCollection<PlaceTypeDto>>(types);
    }
}