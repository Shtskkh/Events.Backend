using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations.ValueObjects.Places;

/// <summary>
///     Номер помещения.
/// </summary>
public class PlaceNumber : ValueObject
{
    public const int MaxLength = 4;

    private PlaceNumber()
    {
    }

    public PlaceNumber(string number)
    {
        Value = new Text(number).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(PlaceNumberErrors.GreaterThanMaxLength);

        if (Value[0] == '-')
            throw new DomainException(PlaceNumberErrors.ContainsMinus);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}