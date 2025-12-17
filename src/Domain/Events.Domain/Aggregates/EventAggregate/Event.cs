using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Interfaces;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>, IAggregateRoot
{
    /// <summary>
    /// Название.
    /// </summary>
    public EventTitle Title { get; private set; }

    /// <summary>
    /// Анонс.
    /// </summary>
    public EventAnnouncement Announcement { get; private set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public EventDescription Description { get; private set; }

    /// <summary>
    /// Максимальное число участников.
    /// </summary>
    public EventMaxParticipants MaxParticipants { get; private set; }

    /// <summary>
    /// Дата и время начала мероприятия.
    /// </summary>
    public DateTimeOffset StarDateTime { get; private set; }

    /// <summary>
    /// Дата и время окончания мероприятия.
    /// </summary>
    public DateTimeOffset EndDateTime { get; private set; }

    /// <summary>
    /// Формат мероприятия.
    /// </summary>
    public EventFormat Format { get; private set; }

    /// <summary>
    /// Флаг публичности.
    /// </summary>
    public bool IsPublic { get; private set; }

    /// <summary>
    /// Флаг необходимости регистрации.
    /// </summary>
    public bool IsNeedsRegistration { get; private set; }

    private readonly List<Tag> _tags = [];

    /// <summary>
    /// Тэги мероприятия.
    /// </summary>
    public IReadOnlyCollection<Tag> Tags => _tags;

    private readonly List<EventPost> _posts = [];

    /// <summary>
    /// Посты во внешних сервисах.
    /// </summary>
    public IReadOnlyCollection<EventPost> Posts => _posts;

    /// <summary>
    /// Организатор мероприятия (создатель)
    /// </summary>
    public Guid OrganizerId { get; private set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="announcement">Анонс.</param>
    /// <param name="description">Описание.</param>
    /// <param name="endDateTime">Дата и время окончания мероприятия.</param>
    /// <param name="startDateTime">Дата и время начала мероприятия.</param>
    /// <param name="maxParticipants">Максимальное число участников.</param>
    /// <param name="isPublic">Флаг публичности.</param>
    /// <param name="isNeedsRegistration">Флаг необходимости регистрации.</param>
    /// <param name="organizerId">Организатор мероприятия (создатель).</param>
    /// <param name="eventFormat">Формат мероприятия.</param>
    public Event(
        string title,
        string announcement,
        string description,
        DateTimeOffset startDateTime,
        DateTimeOffset endDateTime,
        int maxParticipants,
        bool isPublic,
        bool isNeedsRegistration,
        Guid organizerId,
        EventFormat eventFormat
    ) : base(Guid.NewGuid())
    {
        Title = new EventTitle(title);
        Announcement = new EventAnnouncement(announcement);
        Description = new EventDescription(description);
        MaxParticipants = new EventMaxParticipants(maxParticipants);
        IsPublic = isPublic;
        IsNeedsRegistration = isNeedsRegistration;
        OrganizerId = organizerId;
        Format = eventFormat;

        SetDateTimeRange(startDateTime, endDateTime);
    }

    /// <summary>
    /// Изменить название мероприятия.
    /// </summary>
    /// <param name="title">Новое название.</param>
    public void ChangeTitle(string title)
    {
        Title = new EventTitle(title);
    }

    /// <summary>
    /// Изменить анонс мероприятия.
    /// </summary>
    /// <param name="announcement">Новый анонс.</param>
    public void ChangeAnnouncement(string announcement)
    {
        Announcement = new EventAnnouncement(announcement);
    }

    /// <summary>
    /// Изменить описание мероприятия.
    /// </summary>
    /// <param name="description">Новое описание.</param>
    public void ChangeDescription(string description)
    {
        Description = new EventDescription(description);
    }

    /// <summary>
    /// Изменить дату начала и окончания мероприятия.
    /// </summary>
    /// <param name="start">Дата и время начала.</param>
    /// <param name="end">Дата и время окончания.</param>
    public void ChangeDateTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        SetDateTimeRange(start, end);
    }

    private void SetDateTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        if (start >= end)
        {
            throw new DomainException(DomainErrorMessages.EventDateTimeErrors.StartDateCannotBeLaterThanEndDate);
        }

        if (end - start > TimeSpan.FromDays(DomainConstraints.Event.MaxDurationInDays))
        {
            throw new DomainException(DomainErrorMessages.EventDateTimeErrors.DurationGreaterThanMax);
        }

        StarDateTime = start;
        EndDateTime = end;
    }

    /// <summary>
    /// Изменить статус публичности мероприятия.
    /// </summary>
    /// <param name="flag">True или false.</param>
    public void ChangeIsPublic(bool flag)
    {
        IsPublic = flag;
    }

    /// <summary>
    /// Изменить статус необходимости регистрации.
    /// </summary>
    /// <param name="flag">True или false.</param>
    public void ChangeIsNeedsRegistration(bool flag)
    {
        IsNeedsRegistration = flag;
    }

    /// <summary>
    /// Изменить максимальное число участников мероприятия.
    /// </summary>
    /// <param name="newMaxParticipants">Новое максимальное число участников.</param>
    public void ChangeMaxParticipants(int newMaxParticipants)
    {
        MaxParticipants = new EventMaxParticipants(newMaxParticipants);
    }

    /// <summary>
    /// Изменить формат мероприятия.
    /// </summary>
    /// <param name="eventFormat">Новый формат.</param>
    public void ChangeFormat(EventFormat eventFormat)
    {
        Format = eventFormat;
    }

    /// <summary>
    /// Добавить тэг мероприятию.
    /// </summary>
    /// <param name="newTag">Тэг.</param>
    /// <exception cref="DomainException">Тэг уже добавлен.</exception>
    public void AddTag(Tag newTag)
    {
        if (_tags.Any(et => et == newTag))
        {
            throw new DomainException(DomainErrorMessages.TagErrors.TagAlreadyAdded);
        }

        _tags.Add(newTag);
    }

    /// <summary>
    /// Убрать тэг мероприятия.
    /// </summary>
    /// <param name="tag">Тэг.</param>
    /// <exception cref="DomainException">Тэг не найден.</exception>
    public void RemoveTag(Tag tag)
    {
        var eventTag = _tags.FirstOrDefault(et => et == tag);

        if (eventTag == null)
        {
            throw new DomainException(DomainErrorMessages.TagErrors.TagNotFound);
        }

        _tags.Remove(eventTag);
    }

    /// <summary>
    /// Добавить пост.
    /// </summary>
    /// <param name="externalService">Внешний сервис.</param>
    /// <param name="link">Ссылка во внешнем сервисе.</param>
    public void AddPost(ExternalService externalService, Uri link)
    {
        var post = new EventPost(externalService, link);
        _posts.Add(post);
    }

    /// <summary>
    /// Удалить пост.
    /// </summary>
    /// <param name="post">Пост для удаления.</param>
    /// <exception cref="DomainException">
    ///     <see cref="DomainErrorMessages.EventPostErrors.PostNotFound"/>
    /// </exception>
    public void RemovePost(EventPost post)
    {
        var eventPost = _posts.FirstOrDefault(et => et == post);

        if (eventPost == null)
        {
            throw new DomainException(DomainErrorMessages.EventPostErrors.PostNotFound);
        }

        _posts.Remove(eventPost);
    }
}