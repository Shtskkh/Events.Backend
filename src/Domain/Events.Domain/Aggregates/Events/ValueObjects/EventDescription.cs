using Events.Domain.Aggregates.Events.Constraints;
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
    private EventDescription()
    {
    }

    /// <summary>
    ///     Конструктор описания мероприятия.
    /// </summary>
    /// <param name="description">Описание мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventDescription(string description)
    {
        Value = new Text(description).Value;

        if (Value.Length > EventConstraints.Description.MaxLength)
            throw new DomainException(EventErrorMessages.Description.GreaterThanMaxLength);
    }

    /// <summary>
    ///     Строка описания мероприятия.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}