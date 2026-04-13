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

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="capacity">Вместимость.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public PlaceCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new DomainException(PlaceErrorMessages.Capacity.CapacityLessOrEqualZero);

        Value = capacity;
    }

    /// <summary>
    ///     Значение вместимости.
    /// </summary>
    public int Value { get; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}