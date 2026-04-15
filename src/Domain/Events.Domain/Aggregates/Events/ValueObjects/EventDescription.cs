using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Описание мероприятия.
/// </summary>
public class EventDescription : ValueObject
{
    public const int MaxLength = 512;

    private EventDescription()
    {
    }

    public EventDescription(string description)
    {
        Value = new Text(description).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(EventDescriptionErrors.GreaterThanMaxLength(MaxLength));
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}