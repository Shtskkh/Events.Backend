using Ardalis.Specification;
using Events.Domain.Aggregates.EventAggregate;

namespace Events.Application.Services.Features.Events.Specifications;

/// <summary>
///     Базовая спецификация мероприятий.
/// </summary>
public class EventSpec : Specification<Event>
{
    public EventSpec WithId(Guid id)
    {
        Query.Where(e => e.Id == id);
        return this;
    }

    public EventSpec WithIdList(IEnumerable<Guid> ids)
    {
        Query.Where(e => ids.Contains(e.Id));
        return this;
    }

    public EventSpec StartAfter(DateTimeOffset startAfter)
    {
        Query.Where(e => e.DateTimeRange.StartDateTime >= startAfter);
        return this;
    }

    public EventSpec EndBefore(DateTimeOffset endBefore)
    {
        Query.Where(e => e.DateTimeRange.EndDateTime <= endBefore);
        return this;
    }

    public EventSpec WithFormatId(int formatId)
    {
        Query.Where(e => e.Format.Id == formatId);
        return this;
    }

    public EventSpec WithTypeId(int typeId)
    {
        Query.Where(e => e.Type.Id == typeId);
        return this;
    }

    public EventSpec WithUserId(Guid userId)
    {
        Query.Where(e => e.UserId == userId);
        return this;
    }

    public EventSpec WithLocationId(int locationId)
    {
        Query.Where(e => e.Booking != null && e.Booking.LocationId == locationId);
        return this;
    }

    public EventSpec WithPlaceId(int placeId)
    {
        Query.Where(e => e.Booking != null && e.Booking.PlaceId == placeId);
        return this;
    }

    public EventSpec CreatedAfter(DateTimeOffset createdAfter)
    {
        Query.Where(e => e.CreatedAt >= createdAfter);
        return this;
    }

    public EventSpec CreatedBefore(DateTimeOffset createdBefore)
    {
        Query.Where(e => e.CreatedAt <= createdBefore);
        return this;
    }

    public EventSpec IncludeParticipants()
    {
        Query.Include(e => e.Participants);
        return this;
    }

    public new EventSpec AsNoTracking()
    {
        Query.AsNoTracking();
        return this;
    }
}