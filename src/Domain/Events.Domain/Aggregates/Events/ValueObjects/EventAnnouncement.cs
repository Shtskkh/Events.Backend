using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Анонс мероприятия.
/// </summary>
public class EventAnnouncement : ValueObject
{
    public const int MaxLength = 64;

    private EventAnnouncement()
    {
    }

    public EventAnnouncement(string announcement)
    {
        Value = new Text(announcement).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(EventAnnouncementErrors.GreaterThanMaxLength(MaxLength));
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}