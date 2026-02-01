using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
///     Анонс мероприятия.
/// </summary>
public class EventAnnouncement : ValueObject
{
    /// <summary>
    ///     Конструктор анонса мероприятия.
    /// </summary>
    /// <param name="announcement">Анонс мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventAnnouncement(string announcement)
    {
        Announcement = new Text(announcement);

        switch (Announcement.Value.Length)
        {
            case < DomainConstraints.Event.Announcement.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Announcement.LessThanMinLenght);

            case > DomainConstraints.Event.Announcement.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Announcement.GreaterThanMaxLength);
        }
    }

    private Text Announcement { get; }

    /// <summary>
    ///     Строка анонса мероприятия.
    /// </summary>
    public string Value => Announcement.Value;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}