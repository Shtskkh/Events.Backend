using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Locations;
using Events.Domain.Exceptions;
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
    public List<Place> Places { get; } = [];

    /// <summary>
    ///     Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    public DateTime UpdatedAt { get; }

    /// <summary>
    ///     Добавить помещение в локацию.
    /// </summary>
    /// <param name="place">Новое помещение.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public void AddPlace(Place place)
    {
        if (Places.Any(p => p.Number == place.Number))
            throw new DomainException(DomainErrorMessages.Place.Number.AlreadyExists);

        Places.Add(place);
    }
}