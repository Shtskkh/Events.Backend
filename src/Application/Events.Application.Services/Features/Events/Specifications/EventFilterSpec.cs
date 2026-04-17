using Ardalis.Specification;
using Events.Contracts.Events;
using Events.Domain.Aggregates.Events;

namespace Events.Application.Services.Features.Events.Specifications;

public sealed class EventFilterSpec : Specification<Event>
{
    public EventFilterSpec(EventFilterDto filter)
    {
        Query.Include(e => e.Tags);

        if (filter.StartDateTime.HasValue)
            Query.Where(e => e.DateTimeRange.StartDateTime >= filter.StartDateTime.Value);

        if (filter.EndDateTime.HasValue)
            Query.Where(e => e.DateTimeRange.StartDateTime <= filter.EndDateTime.Value);

        if (filter.TypeId.HasValue)
            Query.Where(e => e.Type.Id == filter.TypeId.Value);

        if (filter.FormatId.HasValue)
            Query.Where(e => e.Format.Id == filter.FormatId.Value);

        if (filter.UserId.HasValue)
            Query.Where(e => e.UserId == filter.UserId.Value);

        if (filter.LocationId.HasValue)
            Query.Where(e => e.Booking != null && e.Booking.LocationId == filter.LocationId.Value);

        if (filter.PlaceId.HasValue)
            Query.Where(e => e.Booking != null && e.Booking.PlaceId == filter.PlaceId.Value);

        if (filter.CreatedAfter.HasValue)
            Query.Where(e => e.CreatedAt >= filter.CreatedAfter.Value);

        if (filter.CreatedBefore != null)
            Query.Where(e => e.CreatedAt <= filter.CreatedBefore.Value);

        Query.Skip(filter.Size * (filter.Page - 1));
        Query.Take(filter.Size);

        Query.OrderByDescending(e => e.CreatedAt);

        Query.AsNoTracking();
    }
}