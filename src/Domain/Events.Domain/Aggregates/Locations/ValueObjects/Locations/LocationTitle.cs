using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations.ValueObjects.Locations;

/// <summary>
///     Название локации.
/// </summary>
public class LocationTitle : ValueObject
{
    public const int MaxLength = 256;

    private LocationTitle()
    {
    }

    public LocationTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(LocationTitleErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}