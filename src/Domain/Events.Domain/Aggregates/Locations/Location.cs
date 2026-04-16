using Events.Domain.Aggregates.Locations.Errors;
using Events.Domain.Aggregates.Locations.ValueObjects.Locations;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Errors;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations;

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
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
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
    public DateTimeOffset CreatedAt { get; }

    /// <summary>
    ///     Дата обновления.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; }

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
    ///     Добавить помещение в локацию.
    /// </summary>
    /// <param name="place">Новое помещение.</param>
    /// <exception cref="DomainException">
    ///     Ошибка правил домена.
    /// </exception>
    public void AddPlace(Place place)
    {
        if (_places.Any(p => p.Number == place.Number))
            throw new DomainException(PlaceNumberErrors.AlreadyExists(place.Number.Value));

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
            throw new NotFoundException(PlaceErrors.NotFoundById(placeId));

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
            throw new DomainException(PhotoErrors.AlreadyExists(filename));

        _photos.Add(new OrderedPhoto(filename, _photos.Count));
    }

    public IReadOnlyCollection<string> SyncPhotos(IReadOnlyCollection<PhotoEntry> photos)
    {
        var existingPhotos = _photos.Select(p => p.Filename).ToHashSet();

        foreach (var photo in photos.Where(p => !p.IsNew))
            if (!existingPhotos.Contains(photo.Filename))
                throw new DomainException(PhotoErrors.NotFound(photo.Filename));

        var toDelete = existingPhotos.Except(photos.Select(p => p.Filename)).ToList();

        _photos.Clear();
        _photos.AddRange(photos.Select((entry, index) => new OrderedPhoto(entry.Filename, index)));

        return toDelete;
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
            throw new NotFoundException(PhotoErrors.NotFound(filename));

        _photos.Remove(photo);
    }
}