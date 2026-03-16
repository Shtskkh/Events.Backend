using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Сущность мероприятия.
/// </summary>
public class Event : Entity<Guid>, IAuditable, IAggregateRoot
{
    private readonly List<EventParticipant> _participants = [];

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
    /// <param name="startDateTime">Дата и время начала мероприятия.</param>
    /// <param name="endDateTime">Дата и время окончания мероприятия.</param>
    /// <param name="eventType">Тип мероприятия.</param>
    /// <param name="eventFormat">Формат мероприятия.</param>
    /// <param name="userId">ID пользователя.</param>
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    /// <param name="maxParticipants">Максимальное количество участников.</param>
    /// <param name="previewFilename">Название превью файла.</param>
    /// <param name="placeholderFilename">Название файла плейсхолдера превью.</param>
    public Event(Guid id, EventTitle title, EventAnnouncement announcement, EventDescription description,
        DateTimeOffset startDateTime, DateTimeOffset endDateTime, EventType eventType, EventFormat eventFormat,
        Guid userId, bool needsRegistration, int? maxParticipants = null, string? previewFilename = null,
        string? placeholderFilename = null) : base(id)
    {
        Title = title;
        Announcement = announcement;
        Description = description;
        Type = eventType;
        Format = eventFormat;
        NeedsRegistration = needsRegistration;
        MaxParticipants = maxParticipants;
        PreviewFilename = previewFilename;
        PlaceholderFilename = placeholderFilename;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;

        SetDateTimeRange(startDateTime, endDateTime);
    }

    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public EventTitle Title { get; private set; } = null!;

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public EventAnnouncement Announcement { get; private set; } = null!;

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public EventDescription Description { get; private set; } = null!;

    /// <summary>
    ///     Дата и время начала мероприятия.
    /// </summary>
    public DateTimeOffset StartDateTime { get; private set; }

    /// <summary>
    ///     Дата и время окончания мероприятия.
    /// </summary>
    public DateTimeOffset EndDateTime { get; private set; }

    /// <summary>
    ///     Название файла превью.
    /// </summary>
    public string? PreviewFilename { get; private set; }

    /// <summary>
    ///     Название файла плейсхолдера превью.
    /// </summary>
    public string? PlaceholderFilename { get; }

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public EventType Type { get; private set; } = null!;

    /// <summary>
    ///     Формат мероприятия.
    /// </summary>
    public EventFormat Format { get; private set; } = null!;

    /// <summary>
    ///     Флаг необходимости регистрации на мероприятие.
    /// </summary>
    public bool NeedsRegistration { get; private set; }

    /// <summary>
    ///     Максимальное число участников.
    /// </summary>
    public int? MaxParticipants { get; }

    /// <summary>
    ///     ID пользователя, создавшего мероприятие.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    ///     Участники мероприятия.
    /// </summary>
    public IReadOnlyCollection<EventParticipant> Participants => _participants.AsReadOnly();

    /// <inheritdoc />
    public DateTime CreatedAt { get; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; }

    private void SetDateTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        if (start >= end)
            throw new DomainException(DomainErrorMessages.Event.DateTimeRange.StartLaterThanEnd);

        if (end - start > TimeSpan.FromDays(DomainConstraints.Event.DateTimeRange.MaxDurationInDays))
            throw new DomainException(DomainErrorMessages.Event.DateTimeRange.DurationGreaterThanMax);

        StartDateTime = start;
        EndDateTime = end;
    }

    /// <summary>
    ///     Метод изменения названия мероприятия.
    /// </summary>
    /// <param name="title">Новое название.</param>
    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }

    /// <summary>
    ///     Метод изменения анонса мероприятия.
    /// </summary>
    /// <param name="announcement">Новый анонс.</param>
    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new EventAnnouncement(announcement);
    }

    /// <summary>
    ///     Метод изменения описания мероприятия.
    /// </summary>
    /// <param name="description">Новое описание.</param>
    public void ChangeDescription(string description)
    {
        Description = new EventDescription(description);
    }

    /// <summary>
    ///     Изменить название файла превью.
    /// </summary>
    /// <param name="previewFileName">Название нового файла.</param>
    public void ChangePreviewFilename(string previewFileName)
    {
        PreviewFilename = previewFileName;
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
    ///     Добавить участника.
    /// </summary>
    /// <param name="userId">Идентификатор участника.</param>
    /// <exception cref="DomainException">Ошибка правил домена.</exception>
    public void AddParticipant(Guid userId)
    {
        if (!NeedsRegistration)
            throw new DomainException(DomainErrorMessages.Event.Participant.RegistrationNotRequired);

        if (_participants.Any(p => p.UserId == userId))
            throw new DomainException(DomainErrorMessages.Event.Participant.AlreadyRegistered);

        if (MaxParticipants.HasValue && _participants.Count >= MaxParticipants.Value)
            throw new DomainException(DomainErrorMessages.Event.Participant.MaxCountReached);

        _participants.Add(new EventParticipant(Id, userId));
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
            throw new NotFoundException(DomainErrorMessages.Event.Participant.NotFound);

        _participants.Remove(participant);
    }
}