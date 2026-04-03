using Events.Domain.Aggregates.EventAggregate.Constraints;
using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
///     Анонс мероприятия.
/// </summary>
public class EventAnnouncement : ValueObject
{
    private EventAnnouncement()
    {
    }

    /// <summary>
    ///     Конструктор анонса мероприятия.
    /// </summary>
    /// <param name="announcement">Анонс мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventAnnouncement(string announcement)
    {
        Value = new Text(announcement).Value;

        if (Value.Length > EventConstraints.Announcement.MaxLength)
            throw new DomainException(EventErrorMessages.Announcement.GreaterThanMaxLength);
    }

    /// <summary>
    ///     Строка анонса мероприятия.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}