using Events.Domain.Aggregates.Locations.ValueObjects.Places;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Errors;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Locations;

/// <summary>
///     Помещение.
/// </summary>
public class Place : Entity<int>, IAuditable
{
    /// <summary>
    ///     Фотографии.
    /// </summary>
    private readonly List<OrderedPhoto> _photos = [];

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
    /// <param name="locationId">ID локации.</param>
    /// <param name="title">Название помещения.</param>
    public Place(int id, PlaceNumber number, PlaceCapacity capacity, PlaceType type, int locationId,
        PlaceTitle? title = null) :
        base(id)
    {
        Number = number;
        Capacity = capacity;
        Type = type;
        Title = title;
        LocationId = locationId;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
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

    /// <summary>
    ///     Фотографии.
    /// </summary>
    public IReadOnlyList<OrderedPhoto> Photos => _photos.AsReadOnly();

    /// <summary>
    ///     Локация.
    /// </summary>
    public int LocationId { get; }

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; }

    /// <inheritdoc />
    public DateTimeOffset UpdatedAt { get; }

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
            throw new NotFoundException(PhotoErrors.AlreadyExists(filename));

        _photos.Remove(photo);
    }
}