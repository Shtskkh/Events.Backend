using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate;

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
        var value = new Text(title).Value;

        switch (value.Length)
        {
            case < DomainConstraints.Place.Type.MinLength:
                throw new DomainException(DomainErrorMessages.Place.Type.LessThanMinLength);

            case > DomainConstraints.Place.Type.MaxLength:
                throw new DomainException(DomainErrorMessages.Place.Type.GreaterThanMaxLength);
        }

        Title = title;
    }

    /// <summary>
    ///     Строка названия типа помещения.
    /// </summary>
    public string Title { get; } = null!;
}