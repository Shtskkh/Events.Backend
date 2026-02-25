using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Place;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.LocationAggregate;

/// <summary>
///     Помещение.
/// </summary>
public class Place : Entity<int>, IAuditable
{
    private Place()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="number">Номер помещения.</param>
    /// <param name="type">Тип помещения.</param>
    /// <param name="title">Название помещения.</param>
    public Place(int id, PlaceNumber number, PlaceType type, PlaceTitle? title = null) : base(id)
    {
        Number = number;
        Type = type;
        Title = title;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Номер помещения.
    /// </summary>
    public PlaceNumber Number { get; private set; } = null!;

    /// <summary>
    ///     Тип помещения.
    /// </summary>
    public PlaceType Type { get; private set; } = null!;

    /// <summary>
    ///     Название помещения.
    /// </summary>
    public PlaceTitle? Title { get; private set; }

    /// <inheritdoc />
    public DateTime CreatedAt { get; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; }
}