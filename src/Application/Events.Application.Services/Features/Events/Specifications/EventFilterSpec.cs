using Ardalis.Specification;
using Events.Contracts.Events;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Спецификация фильтра мероприятий.
/// </summary>
public class EventFilterSpec : Specification<Event>
{
    /// <summary>
    ///     Конструктор спецификации фильтра мероприятий.
    /// </summary>
    /// <param name="filter">DTO фильтра.</param>
    public EventFilterSpec(EventFilterDto filter)
    {
        if (filter.StartDateTime != null)
            Query.Where(e => e.DateTimeRange.StartDateTime >= filter.StartDateTime);

        if (filter.EndDateTime != null)
            Query.Where(e => e.DateTimeRange.EndDateTime <= filter.EndDateTime);

        if (filter.TypeId != null)
            Query.Where(e => e.Type.Id == filter.TypeId);

        if (filter.FormatId != null)
            Query.Where(e => e.Format.Id == filter.FormatId);

        if (filter.UserId != null)
            Query.Where(e => e.UserId == filter.UserId);

        if (filter.LocationId != null)
            Query.Where(e => e.Booking != null && e.Booking.LocationId == filter.LocationId);

        if (filter.PlaceId != null)
            Query.Where(e => e.Booking != null && e.Booking.PlaceId == filter.PlaceId);

        if (filter.CreatedAfter != null)
            Query.Where(e => e.CreatedAt >= filter.CreatedAfter);

        if (filter.CreatedBefore != null)
            Query.Where(e => e.CreatedAt <= filter.CreatedBefore);

        Query.OrderByDescending(e => e.CreatedAt);
        Query.AsNoTracking();
        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);
    }
}