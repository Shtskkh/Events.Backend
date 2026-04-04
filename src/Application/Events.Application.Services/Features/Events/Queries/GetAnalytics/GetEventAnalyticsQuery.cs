using Events.Contracts.Events;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAnalytics;

/// <inheritdoc />
public sealed record GetEventAnalyticsQuery(Guid Id) : IRequest<EventAnalyticDto>;