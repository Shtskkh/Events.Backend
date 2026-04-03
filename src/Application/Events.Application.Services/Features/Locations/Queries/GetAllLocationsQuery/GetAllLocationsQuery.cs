using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Locations.Queries.GetAllLocationsQuery;

/// <summary>
///     Запрос на получение всех локаций.
/// </summary>
public record GetAllLocationsQuery : IRequest<IReadOnlyCollection<ShortLocationDto>>;