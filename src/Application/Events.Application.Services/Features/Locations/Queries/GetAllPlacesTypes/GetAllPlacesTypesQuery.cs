using Events.Contracts.Places.PlacesTypes;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAllPlacesTypes;

/// <summary>
///     Запрос на получение всех типов помещений.
/// </summary>
public record GetAllPlacesTypesQuery : IRequest<IReadOnlyCollection<PlaceTypeDto>>;