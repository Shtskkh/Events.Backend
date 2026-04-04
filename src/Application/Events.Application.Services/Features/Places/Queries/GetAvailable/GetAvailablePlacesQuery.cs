using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Places.Queries.GetAvailable;

/// <summary>
///     Запрос доступных помещений в локации на указанный временной слот.
/// </summary>
/// <param name="LocationId">ID локации.</param>
/// <param name="Start">Начало желаемого бронирования.</param>
/// <param name="End">Конец желаемого бронирования.</param>
public record GetAvailablePlacesQuery(
    int LocationId,
    DateTimeOffset Start,
    DateTimeOffset End
) : IRequest<IReadOnlyCollection<PlaceAvailabilityDto>>;