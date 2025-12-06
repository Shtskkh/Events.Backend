using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
/// Анонс мероприятия.
/// </summary>
public class EventAnnouncement : ValueObject
{
    /// <summary>
    /// Строка анонса.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="announcement">Строка анонса.</param>
    /// <exception cref="DomainException">
    /// <see cref="DomainErrorMessages.EventAnnouncementErrors"/>
    /// </exception>
    public EventAnnouncement(string announcement)
    {
        if (string.IsNullOrWhiteSpace(announcement))
        {
            throw new DomainException(DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementNullOrWhiteSpace);
        }

        switch (announcement.Length)
        {
            case < DomainConstraints.EventAnnouncement.MinLength:
                throw new DomainException(
                    DomainErrorMessages.EventAnnouncementErrors.EventAnnouncementLessThanMinLength);

            case > DomainConstraints.EventAnnouncement.MaxLength:
                throw new DomainException(DomainErrorMessages.EventAnnouncementErrors
                    .EventAnnouncementGreaterThanMaxLength);
        }

        Value = announcement.Trim();
    }

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}