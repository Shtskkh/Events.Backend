using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventAnalytics;

public sealed record GetEventAnalyticsQuery(Guid EventId) : IRequest<EventAnalyticsDto>;