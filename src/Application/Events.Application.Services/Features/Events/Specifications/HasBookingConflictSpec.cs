using Ardalis.Specification;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

public class HasBookingConflictSpec : Specification<Event>
{
    public HasBookingConflictSpec(int placeId, DateTimeOffset start, DateTimeOffset end)
    {
        Query.Where(e =>
            e.Booking != null &&
            e.Booking.PlaceId == placeId &&
            e.DateTimeRange.StartDateTime < end &&
            e.DateTimeRange.EndDateTime > start);
    }
}