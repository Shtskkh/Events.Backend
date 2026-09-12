using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventsAnalytics;

public sealed record GetEventsAnalyticsQuery : IRequest<EventsAnalyticsDto>;