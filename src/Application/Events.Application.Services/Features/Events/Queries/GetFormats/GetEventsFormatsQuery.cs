using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetFormats;

/// <summary>
///     Запрос на получение всех форматов мероприятий.
/// </summary>
public sealed record GetEventsFormatsQuery : IRequest<IReadOnlyCollection<EventFormatDto>>;