using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

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

        switch (Value.Length)
        {
            case < DomainConstraints.Event.Description.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Description.LessThanMinLenght);

            case > DomainConstraints.Event.Description.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Description.GreaterThanMaxLength);
        }
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