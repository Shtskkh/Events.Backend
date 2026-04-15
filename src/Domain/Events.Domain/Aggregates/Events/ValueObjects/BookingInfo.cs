using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Информация о бронировании.
/// </summary>
public sealed class BookingInfo : ValueObject
{
    private BookingInfo()
    {
    }

    public BookingInfo(int locationId, int placeId)
    {
        if (locationId <= 0)
            throw new DomainException(EventBookingErrors.LocationIdLessOrEqualToZero);

        if (placeId <= 0)
            throw new DomainException(EventBookingErrors.PlaceIdLessOrEqualToZero);

        LocationId = locationId;
        PlaceId = placeId;
    }

    public int LocationId { get; }
    public int PlaceId { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return LocationId;
        yield return PlaceId;
    }
}