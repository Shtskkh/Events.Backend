using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects.Place;

/// <summary>
///     Название помещения.
/// </summary>
public class PlaceTitle : ValueObject
{
    private PlaceTitle()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="title">Название помещения.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public PlaceTitle(string title)
    {
        var value = new Text(title).Value;

        switch (value.Length)
        {
            case < DomainConstraints.Place.Title.MinLength:
                throw new DomainException(DomainErrorMessages.Place.Title.LessThanMinLength);

            case > DomainConstraints.Place.Title.MaxLength:
                throw new DomainException(DomainErrorMessages.Place.Title.GreaterThanMaxLength);
        }

        Value = value;
    }

    /// <summary>
    ///     Строка названия помещения.
    /// </summary>
    public string Value { get; } = null!;

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}