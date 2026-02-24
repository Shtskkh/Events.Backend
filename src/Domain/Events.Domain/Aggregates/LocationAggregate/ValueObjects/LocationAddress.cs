using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects;

/// <summary>
///     Адрес локации.
/// </summary>
public class LocationAddress : ValueObject
{
    private LocationAddress()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="address">Адрес.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public LocationAddress(string address)
    {
        var value = new Text(address).Value;

        switch (value.Length)
        {
            case < DomainConstraints.Location.Address.MinLength:
                throw new DomainException(DomainErrorMessages.Location.Address.LessThanMinLength);

            case > DomainConstraints.Location.Address.MaxLength:
                throw new DomainException(DomainErrorMessages.Location.Address.GreaterThanMaxLength);
        }

        Value = value;
    }

    /// <summary>
    ///     Строка адреса локации.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}