using Events.Domain.Aggregates.LocationAggregate.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate.ValueObjects.Places;

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
        Value = new Text(title).Value;

        if (Value.Length > DomainConstraints.Place.Title.MaxLength)
            throw new DomainException(PlaceErrorMessages.Title.GreaterThanMaxLength);
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