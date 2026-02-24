using Events.Domain.Aggregates.LocationAggregate.ValueObjects;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.LocationAggregate;

/// <summary>
///     Локация.
/// </summary>
public class Location : Entity<int>, IAuditable, IAggregateRoot
{
    private Location()
    {
    }

    /// <summary>
    ///     Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название локации.</param>
    /// <param name="address">Адрес локации.</param>
    public Location(int id, LocationTitle title, LocationAddress address) : base(id)
    {
        Title = title;
        Address = address;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    ///     Название локации.
    /// </summary>
    public LocationTitle Title { get; private set; } = null!;

    /// <summary>
    ///     Адрес локации.
    /// </summary>
    public LocationAddress Address { get; private set; } = null!;

    /// <summary>
    ///     Помещения в локации.
    /// </summary>
    public List<Place> Places { get; private set; } = [];

    /// <summary>
    ///     Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    public DateTime UpdatedAt { get; }
}