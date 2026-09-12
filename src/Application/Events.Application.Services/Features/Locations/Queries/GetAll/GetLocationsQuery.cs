using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAll;

public sealed record GetLocationsQuery : IRequest<IReadOnlyCollection<ShortLocationDto>>;