using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects;

/// <summary>
///     Название локации.
/// </summary>
public class LocationTitle : ValueObject
{
    private LocationTitle()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="title">Название локации.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public LocationTitle(string title)
    {
        Value = new Text(title).Value;

        switch (Value.Length)
        {
            case < DomainConstraints.Location.Title.MinLength:
                throw new DomainException(DomainErrorMessages.Location.Title.LessThanMinLength);

            case > DomainConstraints.Location.Title.MaxLength:
                throw new DomainException(DomainErrorMessages.Location.Title.GreaterThanMaxLength);
        }
    }

    /// <summary>
    ///     Строка названия локации.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}