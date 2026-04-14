using Events.Domain.Aggregates.Locations.Constraints;
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
    private PlaceNumber()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="number">Номер помещения.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public PlaceNumber(string number)
    {
        Value = new Text(number).Value;

        if (Value.Length > PlaceConstraints.Number.MaxLength)
            throw new DomainException(PlaceErrorMessages.Number.GreaterThanMaxLength);

        if (Value[0] == '-')
            throw new DomainException(PlaceErrorMessages.Number.ContainsMinus);
    }

    /// <summary>
    ///     Строка номера помещения.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}