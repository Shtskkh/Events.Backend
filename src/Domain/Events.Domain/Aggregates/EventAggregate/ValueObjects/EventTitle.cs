using Events.Domain.Aggregates.EventAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
///     Название мероприятия.
/// </summary>
public class EventTitle : ValueObject
{
    private EventTitle()
    {
    }

    /// <summary>
    ///     Конструктор названия мероприятия.
    /// </summary>
    /// <param name="title">Название мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > DomainConstraints.Event.Title.MaxLength)
            throw new DomainException(EventErrorMessages.Title.GreaterThanMaxLength);
    }

    /// <summary>
    ///     Строка названия мероприятия.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}