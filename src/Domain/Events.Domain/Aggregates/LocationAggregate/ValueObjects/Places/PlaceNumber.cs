using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects.Places;

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

        switch (Value.Length)
        {
            case < DomainConstraints.Place.Number.MinLength:
                throw new DomainException(DomainErrorMessages.Place.Number.LessThanMinLength);

            case > DomainConstraints.Place.Number.MaxLength:
                throw new DomainException(DomainErrorMessages.Place.Number.GreaterThanMaxLength);
        }

        if (Value.Contains('-'))
            throw new DomainException(DomainErrorMessages.Place.Number.ContainsMinus);
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