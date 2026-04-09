using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventAnalytics;

/// <inheritdoc />
public sealed record GetEventAnalyticsQuery(Guid Id) : IRequest<EventAnalyticsDto>;