using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Участник мероприятия.
/// </summary>
public class EventParticipant : ValueObject
{
    private EventParticipant()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="eventId">Идентификатор мероприятия.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    public EventParticipant(Guid eventId, Guid userId)
    {
        EventId = eventId;
        UserId = userId;
        RegistrationTime = DateTime.UtcNow;
    }

    /// <summary>
    ///     Идентификатор мероприятия.
    /// </summary>
    public Guid EventId { get; }

    /// <summary>
    ///     Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    ///     Дата регистрации.
    /// </summary>
    public DateTime RegistrationTime { get; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return EventId;
        yield return UserId;
        yield return RegistrationTime;
    }
}