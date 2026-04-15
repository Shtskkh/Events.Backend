using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations.ValueObjects.Places;

/// <summary>
///     Название помещения.
/// </summary>
public class PlaceTitle : ValueObject
{
    public const int MaxLength = 64;

    private PlaceTitle()
    {
    }

    public PlaceTitle(string title)
    {
        Value = new Text(title).Value;

        if (Value.Length > MaxLength)
            throw new DomainException(PlaceTitleErrors.GreaterThanMaxLength);
    }

    public string Value { get; } = null!;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}