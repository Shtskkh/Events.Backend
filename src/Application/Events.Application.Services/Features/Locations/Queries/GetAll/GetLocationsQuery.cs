using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAll;

/// <summary>
///     Запрос на получение всех локаций.
/// </summary>
public sealed record GetLocationsQuery : IRequest<IReadOnlyCollection<ShortLocationDto>>;