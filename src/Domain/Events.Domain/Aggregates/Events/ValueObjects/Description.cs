using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events.ValueObjects;

/// <summary>
///     Описание мероприятия.
/// </summary>
public class Description : ValueObject
{
    public const int MaxLength = 512;

    private Description()
    {
    }

    public Description(string description)
    {
        Value = new Text(description).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(EventDescriptionErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}