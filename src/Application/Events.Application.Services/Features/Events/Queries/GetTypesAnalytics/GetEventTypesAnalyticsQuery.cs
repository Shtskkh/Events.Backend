using Events.Contracts.Events.EventsTypes;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTypesAnalytics;

public sealed record GetEventTypesAnalytics(
    DateTimeOffset? Start,
    DateTimeOffset? End)
    : IRequest<IReadOnlyCollection<EventTypeAnalyticsDto>>;