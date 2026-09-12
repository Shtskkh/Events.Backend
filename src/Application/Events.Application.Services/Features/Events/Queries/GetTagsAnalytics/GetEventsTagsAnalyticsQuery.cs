using Events.Contracts.Tags;
using MediatR;

namespace Events.Application.Services.Features.Events.Queries.GetTagsAnalytics;

public sealed record GetEventsTagsAnalyticsQuery(DateTimeOffset? From, DateTimeOffset? To, int? Top)
    : IRequest<IReadOnlyCollection<TagAnalytics>>;