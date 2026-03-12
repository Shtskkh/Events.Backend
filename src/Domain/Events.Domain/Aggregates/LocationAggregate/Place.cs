using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Places;
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
    /// <param name="capacity">Вместимость помещения.</param>
    /// <param name="type">Тип помещения.</param>
    /// <param name="title">Название помещения.</param>
    public Place(int id, PlaceNumber number, PlaceCapacity capacity, PlaceType type, PlaceTitle? title = null) :
        base(id)
    {
        Number = number;
        Capacity = capacity;
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
    ///     Вместимость помещения.
    /// </summary>
    public PlaceCapacity Capacity { get; private set; } = null!;

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

    /// <summary>
    ///     Изменить название локации.
    /// </summary>
    /// <param name="newTitle">Новое название.</param>
    public void ChangeTitle(string? newTitle = null)
    {
        Title = newTitle == null ? null : new PlaceTitle(newTitle);
    }

    /// <summary>
    ///     Изменить вместимость помещения.
    /// </summary>
    /// <param name="newCapacity">Новая вместимость.</param>
    public void ChangeCapacity(int newCapacity)
    {
        Capacity = new PlaceCapacity(newCapacity);
    }

    /// <summary>
    ///     Изменить тип помещения.
    /// </summary>
    /// <param name="newType">Новый тип.</param>
    public void ChangeType(PlaceType newType)
    {
        Type = newType;
    }
}