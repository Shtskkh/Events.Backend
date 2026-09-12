using Events.Contracts.Places.PlacesTypes;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetTypes;

public sealed record GetPlacesTypesQuery : IRequest<IReadOnlyCollection<PlaceTypeDto>>;