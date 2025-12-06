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
    public Event(
        Guid id,
        string title
    ) : base(id)
    {
        Title = new EventTitle(title);
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
    /// <param name="externalServiceId">Id внешнего сервиса.</param>
    /// <param name="link">Ссылка на пост.</param>
    /// <exception cref="DomainException">Пост для данного сервиса уже существует.</exception>
    public void AddPost(int externalServiceId, Uri link)
    {
        if (_posts.Any(p => p.ExternalServiceId == externalServiceId))
        {
            throw new DomainException(DomainErrorMessages.Post.PostAlreadyExistForService);
        }

        var post = new PostInExternalService(Id, externalServiceId, link);
        _posts.Add(post);
    }

    /// <summary>
    /// Удалить пост.
    /// </summary>
    /// <param name="externalServiceId">Id внешнего сервиса.</param>
    /// <exception cref="DomainException">Пост во внешнем сервисе не найден.</exception>
    public void RemovePost(int externalServiceId)
    {
        var post = _posts.FirstOrDefault(p => p.ExternalServiceId == externalServiceId);

        if (post == null)
        {
            throw new DomainException(DomainErrorMessages.Post.PostNotFoundInService);
        }

        _posts.Remove(post);
    }
}