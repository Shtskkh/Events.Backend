using Events.Contracts.Locations;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetLocationAnalytics;

public record GetEventsLocationsAnalyticsQuery(DateTimeOffset? From, DateTimeOffset? To)
    : IRequest<IReadOnlyCollection<LocationAnalyticsDto>>;