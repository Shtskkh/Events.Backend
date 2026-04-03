using Events.Domain.Aggregates.LocationAggregate.Constraints;
using Events.Domain.Aggregates.LocationAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects.Locations;

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
        Value = new Text(address).Value;

        if (Value.Length > LocationConstraints.Address.MaxLength)
            throw new DomainException(LocationErrorMessages.Address.GreaterThanMaxLength);
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