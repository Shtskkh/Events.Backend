using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
/// Максимальное число участников мероприятия.
/// </summary>
public class EventMaxParticipants : ValueObject
{
    /// <summary>
    /// Максимальное количество участников.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="value">Максимальное количество участников.</param>
    /// <exception cref="DomainException">
    /// <see cref="DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin"/>
    /// </exception>
    public EventMaxParticipants(int value)
    {
        Value = value switch
        {
            0 => 0,
            >= DomainConstraints.Event.MinParticipantsCount => value,
            _ => throw new DomainException(DomainErrorMessages.EventErrors.MaxParticipantsCountLessThanMin)
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}