using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAllEventsFormats;

/// <summary>
///     Запрос на получение всех форматов мероприятий.
/// </summary>
public record GetAllEventsFormatsQuery : IRequest<IReadOnlyCollection<EventFormatDto>>;