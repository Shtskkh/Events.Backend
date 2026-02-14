using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Shared;
using Events.Domain.Shared.Interfaces;

namespace Events.Domain.Aggregates.EventAggregate;

/// <summary>
///     Сущность мероприятия.
/// </summary>
public class Event : Entity<Guid>, IAggregateRoot
{
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
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    /// <param name="previewFilename">Название превью файла.</param>
    public Event(Guid id, EventTitle title, EventAnnouncement announcement, EventDescription description,
        DateTimeOffset startDateTime, DateTimeOffset endDateTime, EventType eventType, bool needsRegistration,
        Guid? previewFilename = null) :
        base(id)
    {
        Title = title;
        Announcement = announcement;
        Description = description;
        EventType = eventType;
        NeedsRegistration = needsRegistration;

        if (previewFilename != null && previewFilename != Guid.Empty) PreviewFilename = previewFilename;

        SetDateTimeRange(startDateTime, endDateTime);
    }

    /// <summary>
    ///     Название мероприятия.
    /// </summary>
    public EventTitle Title { get; private set; }

    /// <summary>
    ///     Анонс (краткое описание) мероприятия.
    /// </summary>
    public EventAnnouncement Announcement { get; private set; }

    /// <summary>
    ///     Описание мероприятия.
    /// </summary>
    public EventDescription Description { get; private set; }

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
    public Guid? PreviewFilename { get; private set; }

    /// <summary>
    ///     Тип мероприятия.
    /// </summary>
    public EventType EventType { get; private set; }

    /// <summary>
    ///     Флаг необходимости регистрации на мероприятие.
    /// </summary>
    public bool NeedsRegistration { get; private set; }

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
    public void ChangePreviewFilename(Guid previewFileName)
    {
        PreviewFilename = previewFileName;
    }

    /// <summary>
    ///     Изменить тип мероприятия.
    /// </summary>
    /// <param name="eventType">Новый тип мероприятия.</param>
    public void ChangeEventType(EventType eventType)
    {
        EventType = eventType;
    }

    /// <summary>
    ///     Изменить флаг необходимости регистрации.
    /// </summary>
    /// <param name="needsRegistration">Флаг необходимости регистрации.</param>
    public void ChangeNeedsRegistration(bool needsRegistration)
    {
        NeedsRegistration = needsRegistration;
    }
}