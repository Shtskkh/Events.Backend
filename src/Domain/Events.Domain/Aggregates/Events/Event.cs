using Events.Domain.Aggregates.Events.Errors;
using Events.Domain.Aggregates.Events.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;
using Events.Domain.Shared.ValueObjects;

namespace Events.Domain.Aggregates.Events;

/// <summary>
///     Сущность мероприятия.
/// </summary>
public sealed class Event : Entity<Guid>, IAuditable, IAggregateRoot
{
    private readonly List<Participant> _participants = [];
    private readonly List<Tag> _tags = [];

    private Event()
    {
    }

    /// <summary>
    ///     Конструктор мероприятия.
    /// </summary>
    /// <param name="id">Идентификатор мероприятия.</param>
    /// <param name="title">Название мероприятия.</param>
    /// <param name="announcement">Анонс (краткое описание) мероприятия.</param>
    /// <param name="description">Описание мероприятия.</param>
    /// <param name="dateTimeRange">Диапазон дат проведения мероприятия.</param>
    /// <param name="eventType">Тип мероприятия.</param>
    /// <param name="eventFormat">Формат мероприятия.</param>
    /// <param name="userId">ID пользователя.</param>
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    public Event(Guid id, Title title, Announcement announcement, Description description,
        DateTimeRange dateTimeRange, EventType eventType, EventFormat eventFormat,
        Guid userId, bool needsRegistration) : base(id)
    {
        Title = title;
        Announcement = announcement;
        Description = description;
        DateTimeRange = dateTimeRange;
        Type = eventType;
        Format = eventFormat;
        NeedsRegistration = needsRegistration;
        UserId = userId;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public Title Title { get; private set; } = null!;

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public Announcement Announcement { get; private set; } = null!;

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public Description Description { get; private set; } = null!;

    /// <summary>
    ///     Диапазон дат проведения мероприятия.
    /// </summary>
    public DateTimeRange DateTimeRange { get; private set; } = null!;

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public EventType Type { get; private set; } = null!;

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public EventFormat Format { get; } = null!;

    /// <summary>
    ///     ID пользователя, создавшего мероприятие.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    ///     Флаг необходимости регистрации на мероприятие.
    /// </summary>
    public bool NeedsRegistration { get; private set; }

    /// <summary>
    ///     Максимальное число участников.
    /// </summary>
    public int? MaxParticipants { get; private set; }

    /// <summary>
    ///     Пришедшее количество участников.
    /// </summary>
    public int? FinalParticipantsCount { get; private set; }

    /// <summary>
    ///     Информация о бронировании.
    /// </summary>
    public Booking? Booking { get; private set; }

    /// <summary>
    ///     Название файла превью.
    /// </summary>
    public string? PreviewFilename { get; private set; }

    /// <summary>
    ///     Название файла плейсхолдера превью.
    /// </summary>
    public string? PlaceholderFilename { get; private set; }

    /// <summary>
    ///     Участники мероприятия.
    /// </summary>
    public IReadOnlyCollection<Participant> Participants => _participants.AsReadOnly();

    /// <summary>
    ///     Тэги.
    /// </summary>
    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; }

    /// <inheritdoc />
    public DateTimeOffset UpdatedAt { get; }

    /// <summary>
    ///     Метод изменения названия мероприятия.
    /// </summary>
    /// <param name="title">Новое название.</param>
    public void ChangeTitle(string title)
    {
        Title = new Title(title);
    }

    /// <summary>
    ///     Метод изменения анонса мероприятия.
    /// </summary>
    /// <param name="announcement">Новый анонс.</param>
    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new Announcement(announcement);
    }

    /// <summary>
    ///     Метод изменения описания мероприятия.
    /// </summary>
    /// <param name="description">Новое описание.</param>
    public void ChangeDescription(string description)
    {
        Description = new Description(description);
    }

    /// <summary>
    ///     Изменить диапазон дат мероприятия.
    /// </summary>
    /// <param name="newStart">Новая дата и время начала.</param>
    /// <param name="newEnd">Новая дата и время окончания.</param>
    public void ChangeDateTimeRange(DateTimeOffset newStart, DateTimeOffset newEnd)
    {
        DateTimeRange = new DateTimeRange(newStart, newEnd);
    }

    /// <summary>
    ///     Изменить дату начала мероприятия.
    /// </summary>
    /// <param name="newStart">Новая дата и время начала.</param>
    public void ChangeStartDateTime(DateTimeOffset newStart)
    {
        DateTimeRange = DateTimeRange.WithStart(newStart);
    }

    /// <summary>
    ///     Изменить дату окончания мероприятия.
    /// </summary>
    /// <param name="newEnd">Новая дата и время окончания.</param>
    public void ChangeEndDateTime(DateTimeOffset newEnd)
    {
        DateTimeRange = DateTimeRange.WithEnd(newEnd);
    }

    /// <summary>
    ///     Изменить тип мероприятия.
    /// </summary>
    /// <param name="eventType">Новый тип мероприятия.</param>
    public void ChangeEventType(EventType eventType)
    {
        Type = eventType;
    }

    /// <summary>
    ///     Изменить флаг необходимости регистрации.
    /// </summary>
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    public void ChangeNeedsRegistration(bool needsRegistration)
    {
        NeedsRegistration = needsRegistration;
    }

    /// <summary>
    ///     Изменить название файла превью.
    /// </summary>
    /// <param name="previewFileName">Название нового файла.</param>
    public void ChangePreview(string previewFileName)
    {
        PreviewFilename = previewFileName;
    }

    /// <summary>
    ///     Изменить плейсхолдер.
    /// </summary>
    /// <param name="placeholderFilename">Название файла плейсхолдера.</param>
    public void ChangePlaceHolder(string placeholderFilename)
    {
        PlaceholderFilename = placeholderFilename;
    }

    /// <summary>
    ///     Изменить максимальное количество участников.
    /// </summary>
    /// <param name="maxParticipants">Новое максимальное количество участников.</param>
    public void ChangeMaxParticipants(int maxParticipants)
    {
        MaxParticipants = maxParticipants;
    }

    /// <summary>
    ///     Добавить участника.
    /// </summary>
    /// <param name="userId">Идентификатор участника.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public void AddParticipant(Guid userId)
    {
        if (!NeedsRegistration)
            throw new DomainException(EventParticipantErrors.RegistrationNotRequired);

        if (_participants.Any(p => p.UserId == userId))
            throw new DomainException(EventParticipantErrors.AlreadyRegistered(userId));

        if (MaxParticipants.HasValue && _participants.Count >= MaxParticipants.Value)
            throw new DomainException(EventParticipantErrors.MaxCountReached(MaxParticipants.Value));

        _participants.Add(new Participant(Id, userId));
    }

    /// <summary>
    ///     Удалить участника.
    /// </summary>
    /// <param name="userId">Идентификатор участника.</param>
    /// <exception cref="NotFoundException">Участник не найден.</exception>
    public void RemoveParticipant(Guid userId)
    {
        var participant = _participants.FirstOrDefault(p => p.UserId == userId);

        if (participant == null)
            throw new NotFoundException(EventParticipantErrors.NotFoundById(userId));

        _participants.Remove(participant);
    }

    /// <summary>
    ///     Изменить финальное количество участников.
    /// </summary>
    /// <param name="finalParticipantsCount">Количество пришедших.</param>
    public void ChangeFinalParticipantsCount(int finalParticipantsCount)
    {
        FinalParticipantsCount = finalParticipantsCount;
    }

    /// <summary>
    ///     Забронировать помещение.
    /// </summary>
    /// <param name="locationId">ID локации.</param>
    /// <param name="placeId">ID помещения в локации.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public void Book(int locationId, int placeId)
    {
        if (Format.Id == EventFormat.Online.Id)
            throw new DomainException(EventBookingErrors.NotAllowedForOnline);

        Booking = new Booking(locationId, placeId);
    }

    /// <summary>
    ///     Убрать бронирование.
    /// </summary>
    public void Unbook()
    {
        Booking = null;
    }

    public void AddTag(Tag tag)
    {
        if (_tags.Any(t => t == tag))
            throw new DomainException(TagErrors.AlreadyAssigned(tag));

        _tags.Add(tag);
    }

    public void RemoveTag(int tagId)
    {
        var tagToRemove = _tags.FirstOrDefault(t => t.Id == tagId);

        if (tagToRemove == null)
            throw new NotFoundException(EventErrors.TagNotFoundById(tagId));

        _tags.Remove(tagToRemove);
    }
}