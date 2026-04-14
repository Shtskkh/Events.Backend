using Events.Domain.Aggregates.Locations.Constraints;
using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations;

/// <summary>
///     Тип помещения.
/// </summary>
public class PlaceType : Entity<int>
{
    /// <summary>
    ///     Коворкинг.
    /// </summary>
    public static readonly PlaceType Coworking = new(1, "Коворкинг");

    /// <summary>
    ///     Конференц-зал.
    /// </summary>
    public static readonly PlaceType Conference = new(2, "Конференц-зал");

    /// <summary>
    ///     Аудитория.
    /// </summary>
    public static readonly PlaceType Audience = new(3, "Аудитория");

    private PlaceType()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название типа помещения.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public PlaceType(int id, string title) : base(id)
    {
        Title = new Text(title).Value;

        if (Title.Length > PlaceConstraints.Type.MaxLength)
            throw new DomainException(PlaceErrorMessages.Type.GreaterThanMaxLength);
    }

    /// <summary>
    ///     Строка названия типа помещения.
    /// </summary>
    public string Title { get; } = null!;
}