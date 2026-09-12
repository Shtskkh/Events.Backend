using Events.Contracts.Places;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetPlacesAnalytics;

public sealed record GetEventsPlacesAnalyticsQuery(DateTimeOffset? From, DateTimeOffset? To, int? Top)
    : IRequest<IReadOnlyCollection<PlaceAnalyticsDto>>;