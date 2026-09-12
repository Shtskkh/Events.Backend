using Events.Contracts.Events.EventsFormats;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetEventFormatsAnalytics;

public record GetEventFormatsAnalyticsQuery(
    DateTimeOffset? Start,
    DateTimeOffset? End) : IRequest<IReadOnlyCollection<EventFormatAnalyticsDto>>;