using Events.Contracts.Places.PlacesTypes;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetTypes;

/// <summary>
///     Запрос на получение всех типов помещений.
/// </summary>
public record GetPlacesTypesQuery : IRequest<IReadOnlyCollection<PlaceTypeDto>>;