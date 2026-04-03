using Events.Domain.Aggregates.LocationAggregate.Errors;
using Events.Domain.Aggregates.LocationAggregate.ValueObjects.Locations;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Errors;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.LocationAggregate;

/// <summary>
///     Локация.
/// </summary>
public class Location : Entity<int>, IAuditable, IAggregateRoot
{
    /// <summary>
    ///     Фотографии.
    /// </summary>
    private readonly List<OrderedPhoto> _photos = [];

    /// <summary>
    ///     Помещения в локации.
    /// </summary>
    private readonly List<Place> _places = [];

    // Для EF
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
    public IReadOnlyList<Place> Places => _places.AsReadOnly();

    /// <summary>
    ///     Фотографии.
    /// </summary>
    public IReadOnlyList<OrderedPhoto> Photos => _photos.AsReadOnly();

    /// <summary>
    ///     Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    public DateTime UpdatedAt { get; }

    /// <summary>
    ///     Изменить название локации.
    /// </summary>
    /// <param name="newTitle">Новое название.</param>
    public void ChangeTitle(string newTitle)
    {
        Title = new LocationTitle(newTitle);
    }

    /// <summary>
    ///     Изменить адрес локации.
    /// </summary>
    /// <param name="newAddress">Новый адрес.</param>
    public void ChangeAddress(string newAddress)
    {
        Address = new LocationAddress(newAddress);
    }

    /// <summary>
    ///     Найти помещение в локации.
    /// </summary>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <returns>Помещение.</returns>
    /// <exception cref="NotFoundException">Помещение не найдено.</exception>
    public Place FindPlace(int placeId)
    {
        var place = _places.FirstOrDefault(p => p.Id == placeId);
        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFound);

        return place;
    }

    /// <summary>
    ///     Добавить помещение в локацию.
    /// </summary>
    /// <param name="place">Новое помещение.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public void AddPlace(Place place)
    {
        if (_places.Any(p => p.Number == place.Number))
            throw new DomainException(PlaceErrorMessages.Number.AlreadyExists);

        _places.Add(place);
    }

    /// <summary>
    ///     Удалить помещение.
    /// </summary>
    /// <param name="placeId">Идентификатор помещения.</param>
    /// <exception cref="NotFoundException">Помещение не найдено.</exception>
    public void RemovePlace(int placeId)
    {
        var place = _places.FirstOrDefault(p => p.Id == placeId);
        if (place == null)
            throw new NotFoundException(PlaceErrorMessages.NotFound);

        _places.Remove(place);
    }

    /// <summary>
    ///     Добавить новое фото в конец.
    /// </summary>
    /// <param name="filename">Название файла.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public void AddPhoto(string filename)
    {
        if (_photos.Any(p => p.Filename == filename))
            throw new DomainException(PhotoErrorMessages.AlreadyExists);

        _photos.Add(new OrderedPhoto(filename, _photos.Count));
    }

    /// <summary>
    ///     Удалить фото.
    /// </summary>
    /// <param name="filename">Название файла.</param>
    /// <exception cref="NotFoundException">Ошибка правил домена.</exception>
    public void RemovePhoto(string filename)
    {
        var photo = _photos.FirstOrDefault(p => p.Filename == filename);
        if (photo == null)
            throw new NotFoundException(PhotoErrorMessages.NotFound);

        _photos.Remove(photo);
    }
}