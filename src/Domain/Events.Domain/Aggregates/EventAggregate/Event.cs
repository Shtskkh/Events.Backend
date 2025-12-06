using Events.Domain.Aggregates.EventAggregate.ValueObjects;
using Events.Domain.Exceptions;
using Events.Domain.Interfaces;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>, IAggregateRoot
{
    private readonly List<EventTag> _tags = [];
    private readonly List<PostInExternalService> _posts = [];

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
    /// Флаг публичности.
    /// </summary>
    public bool IsPublic { get; private set; } = false;

    /// <summary>
    /// Флаг необходимости регистрации.
    /// </summary>
    public bool IsNeedsRegistration { get; private set; } = false;

    /// <summary>
    /// Тэги мероприятия.
    /// </summary>
    public IReadOnlyCollection<EventTag> Tags => _tags.AsReadOnly();

    /// <summary>
    /// Посты во внешних сервисах.
    /// </summary>
    public IReadOnlyCollection<PostInExternalService> Posts => _posts.AsReadOnly();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="title">Название.</param>
    /// <param name="announcement">Анонс.</param>
    /// <param name="description">Описание.</param>
    /// <param name="isPublic">Флаг публичности.</param>
    /// <param name="isNeedsRegistration">Флаг необходимости регистрации.</param>
    public Event(
        Guid id,
        string title,
        string announcement,
        string description,
        bool isPublic,
        bool isNeedsRegistration
    ) : base(id)
    {
        Title = new EventTitle(title);
        Announcement = new EventAnnouncement(announcement);
        Description = new EventDescription(description);
        IsPublic = isPublic;
        IsNeedsRegistration = isNeedsRegistration;
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
    /// Добавить тэг мероприятию.
    /// </summary>
    /// <param name="tagId">Id тэга.</param>
    /// <exception cref="DomainException">Тэг уже добавлен.</exception>
    public void AddTag(int tagId)
    {
        var thisTagIsAdded = _tags.Any(et => et.TagId == tagId);

        if (thisTagIsAdded)
        {
            throw new DomainException(DomainErrorMessages.Tag.TagAlreadyAdded);
        }

        var newTag = new EventTag(Id, tagId);
        _tags.Add(newTag);
    }

    /// <summary>
    /// Убрать тэг мероприятия.
    /// </summary>
    /// <param name="tagId">Id тэга.</param>
    /// <exception cref="DomainException">Тэг не найден.</exception>
    public void RemoveTag(int tagId)
    {
        var eventTag = _tags.FirstOrDefault(et => et.TagId == tagId);

        if (eventTag == null)
        {
            throw new DomainException(DomainErrorMessages.Tag.TagNotFound);
        }

        _tags.Remove(eventTag);
    }

    /// <summary>
    /// Добавить пост во внешнем сервисе.
    /// </summary>
    /// <param name="postId">Id поста.</param>
    /// <param name="externalServiceId">Id внешнего сервиса.</param>
    /// <param name="link">Ссылка на пост.</param>
    public void AddPost(int postId, int externalServiceId, Uri link)
    {
        var post = new PostInExternalService(postId, Id, externalServiceId, link);
        _posts.Add(post);
    }

    /// <summary>
    /// Удалить пост.
    /// </summary>
    /// <param name="postId">Id поста.</param>
    /// <exception cref="DomainException">Пост во внешнем сервисе не найден.</exception>
    public void RemovePost(int postId)
    {
        var post = _posts.FirstOrDefault(p => p.Id == postId);

        if (post == null)
        {
            throw new DomainException(DomainErrorMessages.Post.PostNotFound);
        }

        _posts.Remove(post);
    }
}