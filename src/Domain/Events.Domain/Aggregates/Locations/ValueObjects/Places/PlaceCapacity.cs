using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.Locations.ValueObjects.Places;

/// <summary>
///     Вместимость помещения.
/// </summary>
public class PlaceCapacity : ValueObject
{
    private PlaceCapacity()
    {
    }

    public PlaceCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new DomainException(PlaceCapacityErrors.LessOrEqualZero);

        Value = capacity;
    }

    public int Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}