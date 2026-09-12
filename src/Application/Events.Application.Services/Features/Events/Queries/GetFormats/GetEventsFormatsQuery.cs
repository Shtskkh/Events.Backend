using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetFormats;

public sealed record GetEventsFormatsQuery : IRequest<IReadOnlyCollection<EventFormatDto>>;