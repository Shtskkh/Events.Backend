using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations.ValueObjects.Locations;

/// <summary>
///     Адрес локации.
/// </summary>
public class LocationAddress : ValueObject
{
    public const int MaxLength = 256;

    private LocationAddress()
    {
    }

    public LocationAddress(string address)
    {
        Value = new Text(address).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(LocationAddressErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}