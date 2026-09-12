using Events.Contracts.Events.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypes;

public sealed record GetEventsTypesQuery : IRequest<IReadOnlyCollection<EventTypeDto>>;