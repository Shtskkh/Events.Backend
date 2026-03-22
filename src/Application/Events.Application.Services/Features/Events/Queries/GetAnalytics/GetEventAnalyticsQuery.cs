using Events.Contracts.Features.Events.DTOs;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetAnalytics;

/// <inheritdoc />
public record GetEventAnalyticsQuery(Guid Id) : IRequest<EventAnalyticDto>;