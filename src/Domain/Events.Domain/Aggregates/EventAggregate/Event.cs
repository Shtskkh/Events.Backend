using Events.Domain.Entities;
using Events.Domain.Exceptions;
using Events.Domain.Interfaces;
using Events.Domain.Shared;

namespace Events.Domain.Aggregates.EventAggregate;

public class Event : Entity<Guid>, IAggregateRoot
{
    private readonly List<EventTag> _tags = [];

    /// <summary>
    /// Тэги мероприятия.
    /// </summary>
    public IReadOnlyCollection<EventTag> Tags => _tags.AsReadOnly();

    public Event(Guid id) : base(id)
    {
    }

    /// <summary>
    /// Добавить тэг мероприятию.
    /// </summary>
    /// <param name="tag">Тэг.</param>
    /// <exception cref="DomainException">Тэг уже добавлен.</exception>
    public void AddTag(Tag tag)
    {
        var thisTagIsAdded = _tags.Any(et => et.TagId == tag.Id);

        if (thisTagIsAdded)
        {
            throw new DomainException(DomainErrorMessage.TagAlreadyAdded);
        }

        var newTag = new EventTag(Id, tag.Id);
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
            throw new DomainException(DomainErrorMessage.TagNotFound);
        }

        _tags.Remove(eventTag);
    }
}