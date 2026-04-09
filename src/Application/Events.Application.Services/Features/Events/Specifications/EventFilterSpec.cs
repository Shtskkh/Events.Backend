using Ardalis.Specification;
using Events.Contracts.Events;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Спецификация фильтра мероприятий.
/// </summary>
public class EventFilterSpec : EventSpec
{
    public EventFilterSpec(EventFilterDto filter)
    {
        if (filter.StartDateTime != null)
            StartAfter(filter.StartDateTime.Value);

        if (filter.EndDateTime != null)
            EndBefore(filter.EndDateTime.Value);

        if (filter.TypeId != null)
            WithTypeId(filter.TypeId.Value);

        if (filter.FormatId != null)
            WithFormatId(filter.FormatId.Value);

        if (filter.UserId != null)
            WithUserId(filter.UserId.Value);

        if (filter.LocationId != null)
            WithLocationId(filter.LocationId.Value);

        if (filter.PlaceId != null)
            WithPlaceId(filter.PlaceId.Value);

        if (filter.CreatedAfter != null)
            CreatedAfter(filter.CreatedAfter.Value);

        if (filter.CreatedBefore != null)
            CreatedBefore(filter.CreatedBefore.Value);

        Query.OrderByDescending(e => e.CreatedAt);
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);

        AsNoTracking();
    }
}