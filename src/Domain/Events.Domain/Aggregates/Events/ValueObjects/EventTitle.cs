using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Название мероприятия.
/// </summary>
public class EventTitle : ValueObject
{
    public const int MaxLength = 128;

    private EventTitle()
    {
    }

    public EventTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(EventTitleErrors.GreaterThanMaxLength(MaxLength));
    }

    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}