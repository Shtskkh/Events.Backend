using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.EventAggregate.ValueObjects;

/// <summary>
///     Описание мероприятия.
/// </summary>
public class EventDescription : ValueObject
{
    /// <summary>
    ///     Конструктор описания мероприятия.
    /// </summary>
    /// <param name="description">Описание мероприятия.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public EventDescription(string description)
    {
        Description = new Text(description);

        switch (Description.Value.Length)
        {
            case < DomainConstraints.Event.Description.MinLength:
                throw new DomainException(DomainErrorMessages.Event.Description.LessThanMinLenght);

            case > DomainConstraints.Event.Description.MaxLength:
                throw new DomainException(DomainErrorMessages.Event.Description.GreaterThanMaxLength);
        }
    }

    private Text Description { get; }

    /// <summary>
    ///     Строка описания мероприятия.
    /// </summary>
    public string Value => Description.Value;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}